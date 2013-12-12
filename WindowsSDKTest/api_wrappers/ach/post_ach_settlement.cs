using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool post_ach_settlement(SlidePayWindowsSDK context)
        {
            #region Variables

            int company_id = 0;
            int location_id = 0;
            manual_settlement_entry req = new manual_settlement_entry();
            List<manual_settlement_entry> req_list = new List<manual_settlement_entry>();
            string notes = "";
            List<processor_ach_txn_response> ret = new List<processor_ach_txn_response>();
            
            #endregion

            #region Populate-Variables

            Console.Write("Company ID: ");
            try
            {
                company_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert company ID from string to integer.");
                return false;
            }

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

            Console.Write("Notes: ");
            notes = Console.ReadLine();

            while (true)
            {
                req = new manual_settlement_entry();

                Console.WriteLine("Press [ENTER] with no other input to end.");
                Console.Write("bank_account_id: ");
                string bank_str = Console.ReadLine();

                if (string_null_or_empty(bank_str)) break;

                try
                {
                    req.bank_account_id = Convert.ToInt32(bank_str);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to convert input to int for bank_account_id");
                    return false;
                }

                Console.Write("amount: ");
                string amount_str = Console.ReadLine();

                if (string_null_or_empty(amount_str)) break;

                try
                {
                    req.amount = Convert.ToDecimal(amount_str);
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to convert input to decimal for amount");
                    return false;
                }

                req_list.Add(req);
            }

            if (req_list.Count < 1)
            {
                Console.WriteLine("No entries to send, exiting");
                return false;
            }

            #endregion

            #region Process-Request

            ret = context.sp_ach_settlement(
                company_id,
                location_id,
                req_list,
                notes);

            if (ret == null)
            {
                Console.WriteLine("Null response for ach settlement request.");
                return false;
            }

            if (ret.Count < 1)
            {
                Console.WriteLine("Empty response for ach settlement request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("sp_ach_settlement: " + ret.Count + " entries");
            Console.WriteLine("  ID: amount / routing / account");
            Console.WriteLine("      status / transaction_token");

            foreach (processor_ach_txn_response curr in ret)
            {
                Console.WriteLine("  " + curr.settlement_id + ": " + curr.amount + " / " + curr.routing_number + " / " + curr.account_number);
                Console.WriteLine("      " + curr.provider_status + " / " + curr.settlement_transaction_token);
            }
            
            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
