using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool create_stored_payment()
        {
            #region Variables

            string ccn = "";
            string exp_mo = "";
            string exp_yr = "";
            string name_on_card = "";
            string zip = "";
            int location_id = 0;
            int company_id = 0;
            stored_payment ret = new stored_payment();

            #endregion

            #region Populate-Variables

            Console.Write("Credit Card Number: ");
            ccn = Console.ReadLine();

            Console.Write("Expiration Month: ");
            exp_mo = Console.ReadLine();

            Console.Write("Expiration Year: ");
            exp_yr = Console.ReadLine();

            Console.Write("Name on Card: ");
            name_on_card = Console.ReadLine();

            Console.Write("Billing Zip Code: ");
            zip = Console.ReadLine();

            Console.Write("Company ID: ");
            try
            {
                company_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert company_id from string to int.");
                return false;
            }

            Console.Write("Location ID: ");
            try
            {
                location_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert location_id from string to int.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (string_null_or_empty(ccn) ||
                string_null_or_empty(exp_mo) ||
                string_null_or_empty(exp_yr) ||
                string_null_or_empty(name_on_card) ||
                string_null_or_empty(zip))
            {
                Console.WriteLine("One or more fields were not populated.");
                return false;
            }

            if ((company_id <= 0) || (location_id < 0))
            {
                Console.WriteLine("Both company_id and location_id must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            ret = slidepay.sp_create_stored_payment(
                company_id,
                location_id,
                ccn,
                exp_mo,
                exp_yr,
                name_on_card,
                zip);

            if (ret == null)
            {
                Console.WriteLine("Null response for stored payment request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("Stored payment response received: ");
            Console.WriteLine("  " + ret.stored_payment_id + ": " + ret.cc_type + " " + ret.cc_redacted_number + " guid " + ret.guid);
            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
