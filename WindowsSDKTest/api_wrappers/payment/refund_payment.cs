using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool refund_payment(SlidePayWindowsSDK context)
        {
            #region Variables

            int payment_id = 0;
            processor_cc_txn_response curr_resp = new processor_cc_txn_response();

            #endregion

            #region Populate-Variables

            Console.Write("Payment ID: ");
            try
            {
                payment_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert payment ID from string to integer.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (payment_id <= 0)
            {
                Console.WriteLine("Payment ID must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            curr_resp = context.sp_refund_payment(payment_id);

            if (curr_resp == null)
            {
                Console.WriteLine("Null response for refund request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("Refund response received: " + curr_resp.is_approved);
            Console.WriteLine("  " + curr_resp.cc_type + " " + curr_resp.cc_redacted_number + " " + curr_resp.cc_expiry_month + "/" + curr_resp.cc_expiry_year + " " + decimal_tostring(curr_resp.amount));
            Console.WriteLine("  Approval " + curr_resp.approval_code + " Status " + curr_resp.status_code + " " + curr_resp.status_message + " " + curr_resp.transaction_state);
            Console.WriteLine("  Response time " + curr_resp.processor_time_ms + "ms");

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
