using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool post_account_report(SlidePayWindowsSDK context)
        {
            #region Variables

            int location_id = 0;
            account_report ret = new account_report();

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

            ret = context.sp_account_report(location_id);
            if (ret == null)
            {
                Console.WriteLine("Null response for account report retrieval request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("account_report retrieved: ");
            Console.WriteLine("  " + ret.start_time + " to " + ret.end_time);

            if (ret.report_detail != null)
            {
                if (ret.report_detail.Count > 0)
                {
                    foreach (account_report_detail curr_detail in ret.report_detail)
                    {
                        Console.WriteLine("-------------------------------------------------------------------------------");
                        Console.WriteLine("  report for company_id " + curr_detail.company_id + " " + curr_detail.company_name);
                        Console.WriteLine("             location_id " + curr_detail.location_id + " " + curr_detail.location_name);
                        Console.WriteLine("             account_id " + curr_detail.account_id + " " + curr_detail.account_name);

                        Console.WriteLine("  account details:");
                        if (curr_detail.account_record != null)
                        {
                            Console.WriteLine("    " + curr_detail.account_record.account_type + " created " + curr_detail.account_record.created);
                            Console.WriteLine("    " + curr_detail.account_record.description);
                            Console.WriteLine("    reserve amount: " + curr_detail.account_record.reserve_amount);
                        }
                        else
                        {
                            Console.WriteLine("    no account record to show (null)");
                        }

                        if (curr_detail.account_balance != null)
                        {
                            Console.WriteLine("  account balance: " + curr_detail.account_balance.balance);
                        }
                        else
                        {
                            Console.WriteLine("  no account balance to show (null)");
                        }

                        Console.WriteLine("    commit_balance: " + curr_detail.commit_balance);
                        Console.WriteLine("    reserve_amount: " + curr_detail.reserve_amount);
                        Console.WriteLine("    available_balance: " + curr_detail.available_balance);
                        Console.WriteLine("    pending_credits: " + curr_detail.pending_credits);
                        Console.WriteLine("    pending_debits: " + curr_detail.pending_debits);
                        Console.WriteLine("    pending_net: " + curr_detail.pending_net);
                        Console.WriteLine("    pending_balance: " + curr_detail.pending_balance);

                        Console.WriteLine("  ledger entries:");
                        Console.WriteLine("    (balance entries and entries that are newer than balance entry");

                        if (curr_detail.entries != null)
                        {
                            if (curr_detail.entries.Count > 0)
                            {
                                Console.WriteLine("    ID: type / amount / committed / ledgered / date");
                                Console.WriteLine("        notes");
                                foreach (account_ledger curr_ledger in curr_detail.entries)
                                {
                                    string log_string = "    " + curr_ledger.account_ledger_id + ": " + curr_ledger.entry_type + " / ";

                                    switch (curr_ledger.entry_type)
                                    {
                                        case "credit":
                                            log_string += curr_ledger.credit_amount + " / ";
                                            break;

                                        case "debit":
                                            log_string += "(" + curr_ledger.debit_amount + ") / ";
                                            break;

                                        case "balance":
                                            log_string += "NA / ";
                                            break;

                                        default:
                                            log_string += "unknown / ";
                                            break;
                                    }

                                    log_string += curr_ledger.transaction_status + " / " + curr_ledger.ledgered + " / " + Convert.ToDateTime(curr_ledger.created).ToString("MM/dd/yyyy");
                                    Console.WriteLine(log_string);
                                    Console.WriteLine("        " + curr_ledger.description);
                                }
                            }
                            else
                            {
                                Console.WriteLine("    no account ledger records to show (empty)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("    no account ledger records to show (null)");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("  no account detail to show (empty)");
                }
            }
            else
            {
                Console.WriteLine("  no account detail to show (null)");
            }

            Console.WriteLine("===============================================================================");

            #endregion

            return true;
        }
    }
}
