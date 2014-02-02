using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_all_authorizations()
        {
            #region Variables

            List<payment> curr_authorization_list = new List<payment>();

            #endregion

            #region Process-Request

            curr_authorization_list = slidepay.sp_get_all_authorizations();

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
