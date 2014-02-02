using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool key_authorization()
        {
            #region Variables

            string ccn = "";
            string exp_mo = "";
            string exp_yr = "";
            string cvv2 = "";
            string zip = "";
            decimal amount = 0m;
            string notes = "";
            string latitude = "";
            string longitude = "";
            object curr_resp = new object();

            #endregion

            #region Populate-Variables

            Console.Write("Credit Card Number: ");
            ccn = Console.ReadLine();

            Console.Write("Expiration Month: ");
            exp_mo = Console.ReadLine();

            Console.Write("Expiration Year: ");
            exp_yr = Console.ReadLine();

            Console.Write("CVV2: ");
            cvv2 = Console.ReadLine();

            Console.Write("Billing Zip Code: ");
            zip = Console.ReadLine();

            Console.Write("Notes: ");
            notes = Console.ReadLine();

            Console.Write("Latitude: ");
            latitude = Console.ReadLine();

            Console.Write("Longitude: ");
            longitude = Console.ReadLine();

            Console.Write("Amount: ");
            try
            {
                amount = Convert.ToDecimal(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert amount from string to decimal.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (string_null_or_empty(ccn) ||
                string_null_or_empty(exp_mo) ||
                string_null_or_empty(exp_yr) ||
                string_null_or_empty(cvv2) ||
                string_null_or_empty(zip) ||
                string_null_or_empty(notes))
            {
                Console.WriteLine("One or more fields were not populated.");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            curr_resp = slidepay.sp_key_authorization(
                ccn,
                exp_mo,
                exp_yr,
                cvv2,
                zip,
                notes,
                latitude,
                longitude,
                amount);

            if (curr_resp == null)
            {
                Console.WriteLine("Null response for keyed authorization request.");
                return false;
            }

            if (curr_resp is processor_cc_txn_response)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Authorization response received: " + ((processor_cc_txn_response)curr_resp).is_approved);
                Console.WriteLine("  " + ((processor_cc_txn_response)curr_resp).cc_type + " " + ((processor_cc_txn_response)curr_resp).cc_redacted_number + " " + ((processor_cc_txn_response)curr_resp).cc_expiry_month + "/" + ((processor_cc_txn_response)curr_resp).cc_expiry_year + " " + decimal_tostring(((processor_cc_txn_response)curr_resp).amount));
                Console.WriteLine("  Approval " + ((processor_cc_txn_response)curr_resp).approval_code + " Status " + ((processor_cc_txn_response)curr_resp).status_code + " " + ((processor_cc_txn_response)curr_resp).status_message + " " + ((processor_cc_txn_response)curr_resp).transaction_state);
                Console.WriteLine("  Response time " + ((processor_cc_txn_response)curr_resp).processor_time_ms + "ms");
                Console.WriteLine("  Card present " + ((processor_cc_txn_response)curr_resp).cc_present);

                if (((processor_cc_txn_response)curr_resp).is_approved)
                {
                    Console.WriteLine("  Payment ID " + ((processor_cc_txn_response)curr_resp).payment_id);
                    Console.WriteLine("  Stored Payment GUID " + ((processor_cc_txn_response)curr_resp).stored_payment_guid);
                }

                Console.WriteLine("===============================================================================");
                return ((processor_cc_txn_response)curr_resp).is_approved;
            }
            else if (curr_resp is error_message)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Error: " + ((error_message)curr_resp).error_code + " " + ((error_message)curr_resp).error_file + " " + ((error_message)curr_resp).error_text);
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
