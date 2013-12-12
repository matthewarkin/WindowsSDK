using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool post_payment_report(SlidePayWindowsSDK context)
        {
            #region Variables

            int location_id = 0;
            DateTime start_date = DateTime.Now;
            DateTime end_date = DateTime.Now;
            payment_report ret = new payment_report();

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

            Console.Write("Start date: ");
            try
            {
                string start_str = Console.ReadLine();
                if (!string_null_or_empty(start_str)) start_date = Convert.ToDateTime(start_str);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert start date from string to DateTime.");
                return false;
            }

            Console.Write("End date: ");
            try
            {
                string end_str = Console.ReadLine();
                if (!string_null_or_empty(end_str)) end_date = Convert.ToDateTime(end_str);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert end date from string to DateTime.");
                return false;
            }

            #endregion

            #region Process-Request

            ret = context.sp_payment_report(location_id, start_date, end_date);
            if (ret == null)
            {
                Console.WriteLine("Null response for payment report retrieval request.");
                return false;
            }

            Console.WriteLine("===============================================================================");
            Console.WriteLine("payment_report retrieved: ");
            Console.WriteLine("  " + ret.company_name + " / " + ret.location_name);
            Console.WriteLine("  " + ret.start_time + " to " + ret.end_time);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("  sales: " + ret.sales + "  tips: " + ret.tips);
            Console.WriteLine("  refunds: " + ret.refunds + "  fees: " + ret.fees);
            Console.WriteLine("  net: " + ret.net);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("  fees_credit: " + ret.fees_credit + "  fees_visa: " + ret.fees_visa);
            Console.WriteLine("  fees_mc: " + ret.fees_mc + "  fees_discover: " + ret.fees_discover);
            Console.WriteLine("  fees_amex: " + ret.fees_amex + "  fees_other: " + ret.fees_other);
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("  num_txn: " + ret.num_txn + "  num_txn_sales: " + ret.num_txn_sales);
            Console.WriteLine("  num_txn_refunds: " + ret.num_txn_refunds + "  avg_txn_size: " + ret.avg_txn_size);
            Console.WriteLine("  cash:");
            Console.WriteLine("    num_txn_cash: " + ret.num_txn_cash + "  num_txn_cash_sales: " + ret.num_txn_cash_sales);
            Console.WriteLine("    num_txn_cash_tips: " + ret.num_txn_cash_tips + "  num_txn_cash_refunds: " + ret.num_txn_cash_refunds);
            Console.WriteLine("    cash_sales: " + ret.cash_sales + "  cash_tips: " + ret.cash_tips);
            Console.WriteLine("    cash_refunds: " + ret.cash_refunds + "  cash_net: " + ret.cash_net);
            Console.WriteLine("  credit:");
            Console.WriteLine("    num_txn_credit: " + ret.num_txn_credit + "  num_txn_credit_sales: " + ret.num_txn_credit_sales);
            Console.WriteLine("    num_txn_credit_tips: " + ret.num_txn_credit_tips + "  num_txn_credit_refunds: " + ret.num_txn_credit_refunds);
            Console.WriteLine("    credit_sales: " + ret.credit_sales + "  credit_tips: " + ret.credit_tips);
            Console.WriteLine("    credit_refunds: " + ret.credit_refunds + "  credit_net: " + ret.credit_net);
            Console.WriteLine("    credit/visa:");
            Console.WriteLine("      num_txn_cc_visa: " + ret.num_txn_cc_visa + "  num_txn_cc_visa_sales: " + ret.num_txn_cc_visa_sales);
            Console.WriteLine("      num_txn_cc_visa_tips: " + ret.num_txn_cc_visa_tips + "  num_txn_cc_visa_refunds: " + ret.num_txn_cc_visa_refunds);
            Console.WriteLine("      cc_visa_sales: " + ret.cc_visa_sales + "  cc_visa_tips: " + ret.cc_visa_tips);
            Console.WriteLine("      cc_visa_refunds: " + ret.cc_visa_refunds + "  cc_visa_net: " + ret.cc_visa_net);
            Console.WriteLine("    credit/mc:");
            Console.WriteLine("      num_txn_cc_mc: " + ret.num_txn_cc_mc + "  num_txn_cc_mc_sales: " + ret.num_txn_cc_mc_sales);
            Console.WriteLine("      num_txn_cc_mc_tips: " + ret.num_txn_cc_mc_tips + "  num_txn_cc_mc_refunds: " + ret.num_txn_cc_mc_refunds);
            Console.WriteLine("      cc_mc_sales: " + ret.cc_mc_sales + "  cc_mc_tips: " + ret.cc_mc_tips);
            Console.WriteLine("      cc_mc_refunds: " + ret.cc_mc_refunds + "  cc_mc_net: " + ret.cc_mc_net);
            Console.WriteLine("    credit/amex:");
            Console.WriteLine("      num_txn_cc_amex: " + ret.num_txn_cc_amex + "  num_txn_cc_amex_sales: " + ret.num_txn_cc_amex_sales);
            Console.WriteLine("      num_txn_cc_amex_tips: " + ret.num_txn_cc_amex_tips + "  num_txn_cc_amex_refunds: " + ret.num_txn_cc_amex_refunds);
            Console.WriteLine("      cc_amex_sales: " + ret.cc_amex_sales + "  cc_amex_tips: " + ret.cc_amex_tips);
            Console.WriteLine("      cc_amex_refunds: " + ret.cc_amex_refunds + "  cc_amex_net: " + ret.cc_amex_net);
            Console.WriteLine("    credit/discover:");
            Console.WriteLine("      num_txn_cc_discover: " + ret.num_txn_cc_discover + "  num_txn_cc_discover_sales: " + ret.num_txn_cc_discover_sales);
            Console.WriteLine("      num_txn_cc_discover_tips: " + ret.num_txn_cc_discover_tips + "  num_txn_cc_discover_refunds: " + ret.num_txn_cc_discover_refunds);
            Console.WriteLine("      cc_discover_sales: " + ret.cc_discover_sales + "  cc_discover_tips: " + ret.cc_discover_tips);
            Console.WriteLine("      cc_discover_refunds: " + ret.cc_discover_refunds + "  cc_discover_net: " + ret.cc_discover_net);
            Console.WriteLine("    credit/other:");
            Console.WriteLine("      num_txn_cc_other: " + ret.num_txn_cc_other + "  num_txn_cc_other_sales: " + ret.num_txn_cc_other_sales);
            Console.WriteLine("      num_txn_cc_other_tips: " + ret.num_txn_cc_other_tips + "  num_txn_cc_other_refunds: " + ret.num_txn_cc_other_refunds);
            Console.WriteLine("      cc_other_sales: " + ret.cc_other_sales + "  cc_other_tips: " + ret.cc_other_tips);
            Console.WriteLine("      cc_other_refunds: " + ret.cc_other_refunds + "  cc_other_net: " + ret.cc_other_net);
            Console.WriteLine("  coupon:");
            Console.WriteLine("    num_txn_coupon: " + ret.num_txn_coupon + "  num_txn_coupon_sales: " + ret.num_txn_coupon_sales);
            Console.WriteLine("    num_txn_coupon_tips: " + ret.num_txn_coupon_tips + "  num_txn_coupon_refunds: " + ret.num_txn_coupon_refunds);
            Console.WriteLine("    coupon_sales: " + ret.coupon_sales + "  coupon_tips: " + ret.coupon_tips);
            Console.WriteLine("    coupon_refunds: " + ret.coupon_refunds + "  coupon_net: " + ret.coupon_net);
            Console.WriteLine("  gift_certificate:");
            Console.WriteLine("    num_txn_gift_certificate: " + ret.num_txn_gift_certificate + "  num_txn_gift_certificate_sales: " + ret.num_txn_gift_certificate_sales);
            Console.WriteLine("    num_txn_gift_certificate_tips: " + ret.num_txn_gift_certificate_tips + "  num_txn_gift_certificate_refunds: " + ret.num_txn_gift_certificate_refunds);
            Console.WriteLine("    gift_certificate_sales: " + ret.gift_certificate_sales + "  gift_certificate_tips: " + ret.gift_certificate_tips);
            Console.WriteLine("    gift_certificate_refunds: " + ret.gift_certificate_refunds + "  gift_certificate_net: " + ret.gift_certificate_net);
            Console.WriteLine("  check:");
            Console.WriteLine("    num_txn_check: " + ret.num_txn_check + "  num_txn_check_sales: " + ret.num_txn_check_sales);
            Console.WriteLine("    num_txn_check_tips: " + ret.num_txn_check_tips + "  num_txn_check_refunds: " + ret.num_txn_check_refunds);
            Console.WriteLine("    check_sales: " + ret.check_sales + "  check_tips: " + ret.check_tips);
            Console.WriteLine("    check_refunds: " + ret.check_refunds + "  check_net: " + ret.check_net);
            Console.WriteLine("  deal_redemption:");
            Console.WriteLine("    num_txn_deal_redemption: " + ret.num_txn_deal_redemption + "  num_txn_deal_redemption_sales: " + ret.num_txn_deal_redemption_sales);
            Console.WriteLine("    num_txn_deal_redemption_tips: " + ret.num_txn_deal_redemption_tips + "  num_txn_deal_redemption_refunds: " + ret.num_txn_deal_redemption_refunds);
            Console.WriteLine("    deal_redemption_sales: " + ret.deal_redemption_sales + "  deal_redemption_tips: " + ret.deal_redemption_tips);
            Console.WriteLine("    deal_redemption_refunds: " + ret.deal_redemption_refunds + "  deal_redemption_net: " + ret.deal_redemption_net);
            Console.WriteLine("  other:");
            Console.WriteLine("    num_txn_other: " + ret.num_txn_other + "  num_txn_other_sales: " + ret.num_txn_other_sales);
            Console.WriteLine("    num_txn_other_tips: " + ret.num_txn_other_tips + "  num_txn_other_refunds: " + ret.num_txn_other_refunds);
            Console.WriteLine("    other_sales: " + ret.other_sales + "  other_tips: " + ret.other_tips);
            Console.WriteLine("    other_refunds: " + ret.other_refunds + "  other_net: " + ret.other_net);
            Console.WriteLine("-------------------------------------------------------------------------------");

            if (ret.payment_list != null)
            {
                if (ret.payment_list.Count > 0)
                {
                    Console.WriteLine("  payment_detail: " + ret.payment_list.Count + " records");
                    Console.WriteLine("  ID: type / cc_type / cc_last_four / amount / date");
                    foreach (payment_report_detail curr_detail in ret.payment_list)
                    {
                        string log_string = "  " + curr_detail.payment_id + ": " + curr_detail.method + " ";
                        if (String.Compare(curr_detail.method, "CreditCard") == 0)
                        {
                            log_string += "/ " + curr_detail.cc_type + " / " + curr_detail.cc_redacted_number + " ";
                        }

                        log_string += "/ " + curr_detail.amount + " / " + curr_detail.created.ToString("MM/dd/yyyy");
                        Console.WriteLine(log_string);
                    }
                }
                else
                {
                    Console.WriteLine("  payment_detail: no records");
                }
            }
            else
            {
                Console.WriteLine("  payment_detail: null records");
            }

            Console.WriteLine("===============================================================================");



            #endregion

            return true;
        }
    }
}
