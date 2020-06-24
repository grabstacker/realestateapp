namespace BookingClient
{
    partial class BookingFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bookBtn = new System.Windows.Forms.Button();
            this.lstBoxBookings = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.namelbl = new System.Windows.Forms.Label();
            this.emaillbl = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.phonelbl = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.PropertyGroupBox = new System.Windows.Forms.GroupBox();
            this.listViewProperties = new System.Windows.Forms.ListView();
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colClient = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateAvailable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblBookingTime = new System.Windows.Forms.Label();
            this.PropertyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Location = new System.Drawing.Point(29, 45);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(181, 20);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Please Select a property";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Please select a booking slot";
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(682, 579);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(139, 41);
            this.bookBtn.TabIndex = 5;
            this.bookBtn.Text = "Make Booking";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // lstBoxBookings
            // 
            this.lstBoxBookings.FormattingEnabled = true;
            this.lstBoxBookings.ItemHeight = 20;
            this.lstBoxBookings.Location = new System.Drawing.Point(150, 439);
            this.lstBoxBookings.Name = "lstBoxBookings";
            this.lstBoxBookings.Size = new System.Drawing.Size(295, 184);
            this.lstBoxBookings.TabIndex = 3;
            this.lstBoxBookings.SelectedIndexChanged += new System.EventHandler(this.lstBoxBookings_SelectedIndexChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(655, 396);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(166, 26);
            this.textBoxName.TabIndex = 6;
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Location = new System.Drawing.Point(598, 399);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(51, 20);
            this.namelbl.TabIndex = 7;
            this.namelbl.Text = "Name";
            // 
            // emaillbl
            // 
            this.emaillbl.AutoSize = true;
            this.emaillbl.Location = new System.Drawing.Point(598, 431);
            this.emaillbl.Name = "emaillbl";
            this.emaillbl.Size = new System.Drawing.Size(48, 20);
            this.emaillbl.TabIndex = 9;
            this.emaillbl.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(655, 428);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(166, 26);
            this.textBoxEmail.TabIndex = 8;
            // 
            // phonelbl
            // 
            this.phonelbl.AutoSize = true;
            this.phonelbl.Location = new System.Drawing.Point(595, 463);
            this.phonelbl.Name = "phonelbl";
            this.phonelbl.Size = new System.Drawing.Size(55, 20);
            this.phonelbl.TabIndex = 11;
            this.phonelbl.Text = "Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(655, 460);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(166, 26);
            this.textBoxPhone.TabIndex = 10;
            // 
            // PropertyGroupBox
            // 
            this.PropertyGroupBox.Controls.Add(this.listViewProperties);
            this.PropertyGroupBox.Location = new System.Drawing.Point(49, 81);
            this.PropertyGroupBox.Name = "PropertyGroupBox";
            this.PropertyGroupBox.Size = new System.Drawing.Size(903, 272);
            this.PropertyGroupBox.TabIndex = 15;
            this.PropertyGroupBox.TabStop = false;
            this.PropertyGroupBox.Text = "Properties";
            // 
            // listViewProperties
            // 
            this.listViewProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAddress,
            this.colOwner,
            this.colClient,
            this.colDateAvailable});
            this.listViewProperties.HideSelection = false;
            this.listViewProperties.Location = new System.Drawing.Point(36, 40);
            this.listViewProperties.Name = "listViewProperties";
            this.listViewProperties.Size = new System.Drawing.Size(834, 212);
            this.listViewProperties.TabIndex = 0;
            this.listViewProperties.UseCompatibleStateImageBehavior = false;
            this.listViewProperties.View = System.Windows.Forms.View.Details;
            this.listViewProperties.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 100;
            // 
            // colOwner
            // 
            this.colOwner.Text = "Owner";
            this.colOwner.Width = 100;
            // 
            // colClient
            // 
            this.colClient.Text = "Client";
            this.colClient.Width = 100;
            // 
            // colDateAvailable
            // 
            this.colDateAvailable.Text = "Date Available";
            this.colDateAvailable.Width = 100;
            // 
            // lblBookingTime
            // 
            this.lblBookingTime.AutoSize = true;
            this.lblBookingTime.Location = new System.Drawing.Point(515, 537);
            this.lblBookingTime.Name = "lblBookingTime";
            this.lblBookingTime.Size = new System.Drawing.Size(160, 20);
            this.lblBookingTime.TabIndex = 16;
            this.lblBookingTime.Text = "Current booking time:";
            // 
            // BookingFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 666);
            this.Controls.Add(this.lblBookingTime);
            this.Controls.Add(this.PropertyGroupBox);
            this.Controls.Add(this.phonelbl);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.emaillbl);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.namelbl);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBoxBookings);
            this.Controls.Add(this.titleLbl);
            this.Name = "BookingFrm";
            this.Text = "Real Estate App Booking Form";
            this.PropertyGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.ListBox lstBoxBookings;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Label emaillbl;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label phonelbl;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.GroupBox PropertyGroupBox;
        private System.Windows.Forms.ListView listViewProperties;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colOwner;
        private System.Windows.Forms.ColumnHeader colClient;
        private System.Windows.Forms.ColumnHeader colDateAvailable;
        private System.Windows.Forms.Label lblBookingTime;
    }
}