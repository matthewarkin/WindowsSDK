using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool del_bank_account(SlidePayWindowsSDK context)
        {
            #region Variables

            int bank_account_id = 0;

            #endregion

            #region Populate-Variables

            Console.Write("bank_account ID: ");
            try
            {
                bank_account_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert bank_account ID from string to integer.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (bank_account_id <= 0)
            {
                Console.WriteLine("bank_account ID must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            if (context.sp_delete_bank_account(bank_account_id))
            {
                Console.WriteLine("Bank account delete request succeeded");
                return true;
            }
            else
            {
                Console.WriteLine("Bank account delete request failed");
                return false;
            }

            #endregion
        }
    }
}
