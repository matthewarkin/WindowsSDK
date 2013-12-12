using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool post_ach_balance(SlidePayWindowsSDK context)
        {
            #region Variables

            int location_id = 0;
            decimal? curr_balance = 0m;

            #endregion

            #region Populate-Variables

            Console.Write("Location ID: ");
            try
            {
                location_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert location ID from string to integer.");
                return false;
            }

            #endregion

            #region Process-Request

            curr_balance = context.sp_ach_balance(location_id);
            if (curr_balance == null)
            {
                Console.WriteLine("Null response for ach balance retrieval request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("sp_ach_balance: " + curr_balance);
            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
