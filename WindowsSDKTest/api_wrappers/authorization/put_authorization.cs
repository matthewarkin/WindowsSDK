using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool put_authorization()
        {
            #region Variables

            search_filter curr_sf = new search_filter();
            List<search_filter> sfa_list = new List<search_filter>();
            List<payment> curr_authorization_list = new List<payment>();
            DateTime start_time = DateTime.Now;
            DateTime end_time = DateTime.Now;

            #endregion

            #region Populate-Variables

            Console.WriteLine("Supply timestamps in local time.  SlidePay will automatically convert to UTC.");
            Console.Write("Start Time: ");
            try
            {
                start_time = Convert.ToDateTime(Console.ReadLine()).ToUniversalTime();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert from string to DateTime.");
                return false;
            }

            Console.Write("End Time: ");
            try
            {
                end_time = Convert.ToDateTime(Console.ReadLine()).ToUniversalTime();
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert from string to DateTime.");
                return false;
            }

            curr_sf = new search_filter();
            curr_sf.field = "created";
            curr_sf.condition = "greater_than";
            curr_sf.value = start_time.ToString("MM/dd/yyyy hh:mm:sstt");
            sfa_list.Add(curr_sf);

            curr_sf = new search_filter();
            curr_sf.field = "created";
            curr_sf.condition = "less_than";
            curr_sf.value = end_time.ToString("MM/dd/yyyy hh:mm:sstt");
            sfa_list.Add(curr_sf);

            #endregion

            #region Process-Request

            curr_authorization_list = slidepay.sp_put_authorization(sfa_list);

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
