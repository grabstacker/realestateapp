using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingClient
{
   public class Program
    {
        static void Main(string[] args)
        {
            BookingFrm bookingFrm = new BookingFrm();
            Application.Run(bookingFrm);

        }
    }
}
