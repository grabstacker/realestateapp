using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookingClient
{
    public partial class BookingFrm : Form
    {
        //Set all globaly used vars to interact with db data.
        //initialise the db connection
        public MongoClient dbClient = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass%20Community&ssl=false");
        public List<string> propertyList = new List<string>();
        public string currentBookingTime;
        public string propertyAddress;
        public string propertyViewingDate;
        public int positionDelete;
        public List<string> timeSlotArrayEdit = new List<string>();

        public BookingFrm()
        {
            InitializeComponent();

            // //initialise  the propertys from db
            var dbList = dbClient.ListDatabases().ToList();
            var database = dbClient.GetDatabase("Properties");
            var collection = database.GetCollection<BsonDocument>("properties");
            // var filter = Builders<BsonDocument>.Filter.Eq("propName", "asdfhg");
            var documents = collection.Find(new BsonDocument()).ToList();

            //run through each document found add to output list on screen
            foreach (BsonDocument doc in documents)
            {
                var stringTest = doc["timeSlots"].AsBsonArray;

                if (stringTest > 0)
                {
                    propertyList.Add(doc["propAddress"].AsString);
                    var timestamp = doc["dateAvailable"].AsBsonDateTime.ToString();

                    timestamp = timestamp.Remove(10);

                    ListViewItem item = new ListViewItem(new[] { doc["propAddress"].AsString, doc["propOwner"].AsString, doc["propClient"].AsString, timestamp });
                    listViewProperties.Items.Add(item);
                }
            }
        }

        //Get currently selected index and pass the property to corrsponding
        public void lstBoxBookings_SelectedIndexChanged(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You have selected the booking time: " + lstBoxBookings.SelectedItem.ToString() + "\n" + "Are you sure this is the time you want?", "Confirm Time Slot Booking!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                lblBookingTime.Text = "Current booking time: " + lstBoxBookings.SelectedItem.ToString();

                currentBookingTime = lstBoxBookings.SelectedItem.ToString();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        //Check for duplicate property and date and if not submit the new property
        //Check for input validation
        async public void setBooking(string name, string email, string phone)
        {
            if (currentBookingTime != null && propertyAddress != null)
            {
                var database = dbClient.GetDatabase("Properties");
                var collection = database.GetCollection<BsonDocument>("bookings");
                var filter = Builders<BsonDocument>.Filter.Eq("propAddress", propertyAddress);
                var filter2 = Builders<BsonDocument>.Filter.Eq("timeSlot", currentBookingTime);
                var result = collection.Find(Builders<BsonDocument>.Filter.And(filter, filter2)).ToList();
                if (result.Count < 1)
                {
                    var document = new BsonDocument
                {
                    {"propAddress", propertyAddress },
                             {"buyerName", name},
                                      {"buyerEmail",email },
                                               {"buyerPhone",phone },
                                                        {"dateBooked",propertyViewingDate },
                { "timeSlot",currentBookingTime }
                };
                    await collection.InsertOneAsync(document);
                    MessageBox.Show("Submitted apointment");
                }
                else
                {
                    MessageBox.Show("Im sorry that appointment has already been made!");
                }
            }
            else
            {
                MessageBox.Show("You need to select a property and booking time!");
            }
        }

        //handles data vailadation of the input fields and the current state being not null for propAddress and CurrentBookTime
        public void bookBtn_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(textBoxEmail.Text))
            {
                int i = 0;
                bool result = int.TryParse(textBoxPhone.Text, out i);
                if (result)
                {
                    if (textBoxName.Text == "" || textBoxEmail.Text == "" || textBoxPhone.Text == "" || propertyAddress == null || currentBookingTime == null)
                    {
                        MessageBox.Show("You forgot a field!");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Your Booking is as follows: \n" + "Property Address: " + propertyAddress + "\n" + "Booking Time: " + currentBookingTime + "\n" + "Your Name: " + textBoxName.Text + "\n" + " Email: " + textBoxEmail.Text + "\n" + "Contact Phone: " + textBoxPhone.Text + "\n" + "Are these details correct?", "Confirm Time Slot Booking!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //Reset all vars used in the booking for lables and state
                            lblBookingTime.Text = "Current booking time: " + lstBoxBookings.SelectedItem.ToString();

                            currentBookingTime = lstBoxBookings.SelectedItem.ToString();
                            setBooking(textBoxName.Text, textBoxEmail.Text, textBoxPhone.Text);
                            positionDelete = lstBoxBookings.SelectedIndex;
                            removeBookingSlot(propertyAddress, currentBookingTime);
                            currentBookingTime = null;
                            propertyAddress = null;
                            propertyViewingDate = null;
                            lstBoxBookings.Items.Clear();
                            lblBookingTime.Text = "Current booking time: ";
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            //do something else
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not a vaild Phone Number!");
                }
            }
            else
            {
                MessageBox.Show("The email address is not vaild!");
            }
        }

        //checks for an exsisting property address and updates the timeSlotsArray
        public void removeBookingSlot(string propertyaddress, string currentbookingtime)
        {
            var database = dbClient.GetDatabase("Properties");
            var collection = database.GetCollection<BsonDocument>("properties");
            var filter = new BsonDocument("propAddress", propertyaddress);
            timeSlotArrayEdit.RemoveAt(positionDelete);
            var update = Builders<BsonDocument>.Update.Set("timeSlots", timeSlotArrayEdit);
            var document = collection.UpdateOne(filter, update);
        }

        //Checks a vaild email is being attemptedd
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        //Gets the lists view index and property view date available
        //corrosponds that position from the index to the position in the array of properties propList
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewProperties.Enabled = false;
            lstBoxBookings.Items.Clear();
            lblBookingTime.Text = "Current booking time: ";
            currentBookingTime = null;
            propertyAddress = null;

            if (listViewProperties.SelectedItems.Count > 0)
            {
                propertyAddress = listViewProperties.SelectedItems[0].Text;
                propertyViewingDate = listViewProperties.SelectedItems[0].SubItems[3].Text;

                var database = dbClient.GetDatabase("Properties");
                var collection = database.GetCollection<BsonDocument>("properties");
                var filter = new BsonDocument("propAddress", propertyList[listViewProperties.Items.IndexOf(listViewProperties.SelectedItems[0])]);
                var documents = collection.Find(filter).ToList();

                //finds the corrosponding document in the db and pushes the time slots for that document to the lstBoXBookings Items
                foreach (BsonDocument doc in documents)
                {
                    if (doc["timeSlots"].AsBsonArray.Count > 0)
                    {
                        var timeSlotArray = doc["timeSlots"].AsBsonArray.ToArray();
                        lstBoxBookings.Items.Clear();
                        timeSlotArrayEdit.Clear();
                        foreach (var slot in timeSlotArray)
                        {
                            lstBoxBookings.Items.Add(slot);
                            timeSlotArrayEdit.Add(slot.AsString);
                        }
                    }
                    else
                    {
                        timeSlotArrayEdit.Clear();
                        timeSlotArrayEdit.Clear();
                        MessageBox.Show("Sorry no more appointments left!");
                    }
                }
            }
            listViewProperties.Enabled = true;
        }
    }
}