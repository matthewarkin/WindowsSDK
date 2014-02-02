using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_authorization()
        {
            #region Variables

            int authorization_id = 0;
            List<payment> curr_authorization_list = new List<payment>();

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

            curr_authorization_list = slidepay.sp_get_authorization(authorization_id);

            if (curr_authorization_list == null)
            {
                Console.WriteLine("Null response for authorization retrieval request.");
                return false;
            }

            if (curr_authorization_list.Count < 1)
            {
                Console.WriteLine("No authorizations retrieved.");
                return false;
            }

            foreach (payment curr_authorization in curr_authorization_list)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Authorization retrieved: payment_id " + curr_authorization.payment_id);
                Console.WriteLine("  " + curr_authorization.method + " " + curr_authorization.cc_type + " " + curr_authorization.cc_redacted_number + " " + curr_authorization.cc_expiry_month + "/" + curr_authorization.cc_expiry_year + " " + decimal_tostring(curr_authorization.amount));
                Console.WriteLine("  Approval " + curr_authorization.provider_approval_code + " Status " + curr_authorization.provider_status_code + " " + curr_authorization.provider_status_message + " " + curr_authorization.provider_transaction_state);
                Console.WriteLine("  Response time " + curr_authorization.processor_time_ms + "ms");
                Console.WriteLine("  Stored Payment GUID " + curr_authorization.stored_payment_guid);
                Console.WriteLine("===============================================================================");
            }

            #endregion

            return true;
        }
    }
}
