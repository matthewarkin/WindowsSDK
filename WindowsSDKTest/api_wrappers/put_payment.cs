using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool put_payment(SlidePayWindowsSDK context)
        {
            #region Variables

            search_filter curr_sf = new search_filter();
            List<search_filter> sfa_list = new List<search_filter>();
            List<payment> curr_payment_list = new List<payment>();
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

            curr_payment_list = context.sp_put_payment(sfa_list);

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
