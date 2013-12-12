using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool track2_payment()
        {
            #region Variables

            string track2 = "";
            decimal amount = 0m;
            string notes = "";
            processor_cc_txn_response curr_resp = new processor_cc_txn_response();

            #endregion

            #region Populate-Variables

            Console.Write("Track 2 Data: ");
            track2 = Console.ReadLine();

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

            if (string_null_or_empty(track2))
            {
                Console.WriteLine("Track 1 field was not populated.");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Amount must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            curr_resp = slidepay.sp_track2_payment(
                track2,
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
