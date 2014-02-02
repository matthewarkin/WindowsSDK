using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool capture_auth_convert()
        {
            #region Variables

            int authorization_id = 0;
            object resp = new object();

            #endregion

            #region Populate-Variables

            Console.Write("Payment ID: ");
            try
            {
                authorization_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert authorization ID from string to integer.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (authorization_id <= 0)
            {
                Console.WriteLine("Payment ID must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            resp = slidepay.sp_capture_auth_convert(authorization_id);

            if (resp == null)
            {
                Console.WriteLine("Null response for refund request.");
                return false;
            }

            if (resp is bool)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Authorization capture response received: " + (bool)resp); 
                Console.WriteLine("===============================================================================");
                return true;
            }
            else if (resp is error_message)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Error: " + ((error_message)resp).error_code + " " + ((error_message)resp).error_file + " " + ((error_message)resp).error_text);
                Console.WriteLine("===============================================================================");
                return false;
            }
            else
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Null response received");
                Console.WriteLine("===============================================================================");
                return false;
            }

            #endregion
        }
    }
}
