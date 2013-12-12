using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_bank_account()
        {
            #region Variables

            int bank_account_id = 0;
            List<bank_account> curr_bank_account_list = new List<bank_account>();

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

            curr_bank_account_list = slidepay.sp_get_bank_account(bank_account_id);

            if (curr_bank_account_list == null)
            {
                Console.WriteLine("Null response for bank_account retrieval request.");
                return false;
            }

            if (curr_bank_account_list.Count < 1)
            {
                Console.WriteLine("No bank_accounts retrieved.");
                return false;
            }

            foreach (bank_account curr_bank_account in curr_bank_account_list)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("bank_account retrieved: " + curr_bank_account.bank_account_id);
                Console.WriteLine("  type " + curr_bank_account.type + " routing " + curr_bank_account.routing_number + " account " + curr_bank_account.account_number);
                Console.WriteLine("  is_settlement_account " + curr_bank_account.is_settlement_account + " is_verified " + curr_bank_account.is_verified);
                Console.WriteLine("===============================================================================");
            }

            #endregion

            return true;
        }
    }
}
