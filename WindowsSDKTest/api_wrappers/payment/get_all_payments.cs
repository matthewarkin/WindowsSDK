using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_all_payments(SlidePayWindowsSDK context)
        {
            #region Variables

            List<payment> curr_payment_list = new List<payment>();

            #endregion

            #region Process-Request

            curr_payment_list = context.sp_get_all_payments();

            if (curr_payment_list == null)
            {
                Console.WriteLine("Null response for payment retrieval request.");
                return false;
            }

            if (curr_payment_list.Count < 1)
            {
                Console.WriteLine("No payments retrieved.");
                return false;
            }

            foreach (payment curr_payment in curr_payment_list)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Payment retrieved: " + curr_payment.payment_id);
                Console.WriteLine("  " + curr_payment.method + " " + curr_payment.cc_type + " " + curr_payment.cc_redacted_number + " " + curr_payment.cc_expiry_month + "/" + curr_payment.cc_expiry_year + " " + decimal_tostring(curr_payment.amount));
                Console.WriteLine("  Approval " + curr_payment.provider_approval_code + " Status " + curr_payment.provider_status_code + " " + curr_payment.provider_status_message + " " + curr_payment.provider_transaction_state);
                Console.WriteLine("  Response time " + curr_payment.processor_time_ms + "ms");
                Console.WriteLine("  Stored Payment GUID " + curr_payment.stored_payment_guid);
                Console.WriteLine("===============================================================================");
            }

            #endregion

            return true;
        }
    }
}
