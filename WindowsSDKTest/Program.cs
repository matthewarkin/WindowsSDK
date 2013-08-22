using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            string email = "";
            string password = "";
            string proxy_url = "";
            bool run_forever = true;
            string user_input = "";

            #endregion

            #region Welcome

            welcome();

            #endregion

            #region Set-Authentication Parameters

            set_auth_parameters(out email, out password, out proxy_url);

            #endregion

            #region Instantiate-SDK

            /*
             * The default constructor is used in the first example.  Only the email adddress and password
             * need to be supplied.
             * 
             * The second constructor (commented out) enables debugging via the debug output window.
             * 
             * The third constructor (commented out) enables debugging via the debug output window and
             * further routes RESTful HTTPS requests through a configured proxy.  SlidePay recommends
             * using Charles Proxy as a proxy should you need to view requests and responses.
             * 
             */

            // SlidePayWindowsSDK slidepay = new SlidePayWindowsSDK(email, password);
            SlidePayWindowsSDK slidepay = new SlidePayWindowsSDK(email, password, true);
            // SlidePayWindowsSDK slidepay = new SlidePayWindowsSDK(email, password, true, true, proxy_url);

            #endregion

            #region Find-Endpoint

            if (slidepay.sp_find_endpoint())
            {
                Console.WriteLine("Found endpoint: " + slidepay._endpoint_url);
            }
            else
            {
                exit_application("Could not find an endpoint for email " + email);
            }

            #endregion

            #region Login

            if (slidepay.sp_login())
            {
                Console.WriteLine("Successfully authenticated using email " + email);
            }
            else
            {
                exit_application("Unable to authenticate using email " + email);
            }

            #endregion

            #region Menu

            while (run_forever)
            {
                user_input = "";
                Console.WriteLine("");
                Console.Write("SlidePay SDK (? for help) > ");
                user_input = Console.ReadLine();

                if (string_null_or_empty(user_input))
                {
                    Console.WriteLine("Invalid input.  Type '?' and press ENTER for a menu.");
                    Console.WriteLine("");
                    continue;
                }

                switch (user_input)
                {
                    #region General

                    case "?":
                        menu();
                        break;

                    case "q":
                        run_forever = false;
                        break;

                    case "config":
                        display_config(slidepay);
                        break;

                    case "credentials":
                        slidepay.sp_reset();
                        set_auth_parameters(out email, out password, out proxy_url);
                        Console.WriteLine("Token details cleared.  Please find endpoint again and re-authenticate.");
                        slidepay = new SlidePayWindowsSDK(email, password, true);
                        break;

                    case "find_endpoint":
                        if (slidepay.sp_find_endpoint()) Console.WriteLine("Found endpoint: " + slidepay._endpoint_url);
                        else exit_application("Could not find an endpoint for email " + email);
                        break;

                    case "authenticate":
                        if (slidepay.sp_login()) Console.WriteLine("Successfully authenticated using email " + email);
                        else exit_application("Unable to authenticate using email " + email);
                        break;

                    #endregion

                    #region Payment

                    case "key_payment":
                        if (key_payment(slidepay)) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "track1_payment":
                        if (track1_payment(slidepay)) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "track2_payment":
                        if (track2_payment(slidepay)) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "refund_payment":
                        if (refund_payment(slidepay)) Console.WriteLine("Refund request succeeded.");
                        else Console.WriteLine("Refund request failed.");
                        break;

                    case "get_payment":
                        if (get_payment(slidepay)) Console.WriteLine("Payment retrieval request succeeded.");
                        else Console.WriteLine("Payment retrieval request failed.");
                        break;

                    case "get_all_payments":
                        if (get_all_payments(slidepay)) Console.WriteLine("Payment retrieval request succeeded.");
                        else Console.WriteLine("Payment retrieval request failed.");
                        break;

                    case "search_payments":
                        if (put_payment(slidepay)) Console.WriteLine("Payment search request succeeded.");
                        else Console.WriteLine("Payment search request failed.");
                        break;

                    #endregion

                    #region Bank-Account

                    case "get_bank_account":
                        if (get_bank_account(slidepay)) Console.WriteLine("Bank account retrieval request succeeded.");
                        else Console.WriteLine("Bank account retrieval request failed.");
                        break;
                        
                    case "get_all_bank_accounts":
                        if (get_all_bank_accounts(slidepay)) Console.WriteLine("Bank account retrieval request succeeded.");
                        else Console.WriteLine("Bank account retrieval request failed.");
                        break;
                        
                    case "del_bank_account":
                        if (del_bank_account(slidepay)) Console.WriteLine("Bank account delete request succeeded.");
                        else Console.WriteLine("Bank account delete request failed.");
                        break;
                        
                    case "create_bank_account":
                        if (create_bank_account(slidepay)) Console.WriteLine("Bank account creation request succeeded.");
                        else Console.WriteLine("Bank account creation request failed.");
                        break;

                    #endregion

                    default:
                        Console.WriteLine("Unknown command '" + user_input + "'.  Type '?' and press ENTER for a menu.");
                        continue;
                }
            }

            #endregion

            exit_application("Exiting normally.  Goodbye.");
            return;
        }
    }
}
