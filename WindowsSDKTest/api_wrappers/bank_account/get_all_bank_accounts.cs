using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool get_all_bank_accounts(SlidePayWindowsSDK context)
        {
            #region Variables

            List<bank_account> curr_bank_account_list = new List<bank_account>();

            #endregion

            #region Process-Request

            curr_bank_account_list = context.sp_get_all_bank_accounts();

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
