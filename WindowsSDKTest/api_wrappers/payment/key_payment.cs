using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool key_payment()
        {
            #region Variables

            string ccn = "";
            string exp_mo = "";
            string exp_yr = "";
            string cvv2 = "";
            string zip = "";
            decimal amount = 0m;
            string notes = "";
            processor_cc_txn_response curr_resp = new processor_cc_txn_response();

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

            curr_resp = slidepay.sp_key_payment(
                ccn,
                exp_mo,
                exp_yr,
                cvv2,
                zip,
                notes,
                amount);

            if (curr_resp == null)
            {
                Console.WriteLine("Null response for keyed payment request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("Payment response received: " + curr_resp.is_approved);
            Console.WriteLine("  " + curr_resp.cc_type + " " + curr_resp.cc_redacted_number + " " + curr_resp.cc_expiry_month + "/" + curr_resp.cc_expiry_year + " " + decimal_tostring(curr_resp.amount));
            Console.WriteLine("  Approval " + curr_resp.approval_code + " Status " + curr_resp.status_code + " " + curr_resp.status_message + " " + curr_resp.transaction_state);
            Console.WriteLine("  Response time " + curr_resp.processor_time_ms + "ms");
            Console.WriteLine("  Card present " + curr_resp.cc_present);

            if (curr_resp.is_approved)
            {
                Console.WriteLine("  Payment ID " + curr_resp.payment_id);
                Console.WriteLine("  Stored Payment GUID " + curr_resp.stored_payment_guid);
            }

            Console.WriteLine("===============================================================================");

            #endregion

            return curr_resp.is_approved;
        }
    }
}
