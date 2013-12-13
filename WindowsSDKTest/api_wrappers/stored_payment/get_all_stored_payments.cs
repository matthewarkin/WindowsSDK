using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_all_stored_payments()
        {
            #region Variables

            List<stored_payment> curr_stored_payment_list = new List<stored_payment>();

            #endregion

            #region Process-Request

            curr_stored_payment_list = slidepay.sp_get_all_stored_payments();

            if (curr_stored_payment_list == null)
            {
                Console.WriteLine("Null response for stored_payment retrieval request.");
                return false;
            }

            if (curr_stored_payment_list.Count < 1)
            {
                Console.WriteLine("No stored_payments retrieved.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("Stored payment response received: " + curr_stored_payment_list.Count + " entries");
            foreach (stored_payment curr in curr_stored_payment_list)
            {
                Console.WriteLine("  " + curr.stored_payment_id + ": " + curr.cc_type + " " + curr.cc_redacted_number + " guid " + curr.guid);
            }
            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
