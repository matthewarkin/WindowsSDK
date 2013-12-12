using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_payment()
        {
            #region Variables

            int payment_id = 0;
            List<payment> curr_payment_list = new List<payment>();

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

            curr_payment_list = slidepay.sp_get_payment(payment_id);

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
