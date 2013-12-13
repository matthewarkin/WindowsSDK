using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_stored_payment()
        {
            #region Variables

            string guid = "";
            List<stored_payment> ret = new List<stored_payment>();

            #endregion

            #region Populate-Variables

            Console.Write("GUID: ");
            guid = Console.ReadLine();
            
            #endregion

            #region Check-for-Null-or-Bad-Values

            if (string_null_or_empty(guid))
            {
                Console.WriteLine("GUID must not be null.");
                return false;
            }

            #endregion

            #region Process-Request

            ret = slidepay.sp_get_stored_payment(guid);

            if (ret == null)
            {
                Console.WriteLine("Null response for stored_payment retrieval request.");
                return false;
            }

            if (ret.Count < 1)
            {
                Console.WriteLine("No stored_payments retrieved.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("Stored payment response received: " + ret.Count + " entries");
            foreach (stored_payment curr in ret)
            {
                Console.WriteLine("  " + curr.stored_payment_id + ": " + curr.cc_type + " " + curr.cc_redacted_number + " guid " + curr.guid);
            }
            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
