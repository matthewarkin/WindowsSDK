using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool del_stored_payment()
        {
            #region Variables

            int stored_payment_id = 0;

            #endregion

            #region Populate-Variables

            Console.Write("stored_payment ID: ");
            try
            {
                stored_payment_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert stored_payment ID from string to integer.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (stored_payment_id <= 0)
            {
                Console.WriteLine("stored_payment ID must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            if (slidepay.sp_delete_stored_payment(stored_payment_id))
            {
                Console.WriteLine("Stored payment delete request succeeded");
                return true;
            }
            else
            {
                Console.WriteLine("Stored payment delete request failed");
                return false;
            }

            #endregion
        }
    }
}
