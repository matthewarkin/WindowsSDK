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
            string api_key = "";
            string endpoint = "";
            string token = "";
            bool debug_output = true;
            bool run_forever = true;
            string user_input = "";

            #endregion

            #region Welcome

            welcome();

            #endregion

            #region Set-Authentication Parameters

            set_auth_parameters(out email, out password, out proxy_url, out api_key, out endpoint, out token, out debug_output);
            
            #endregion

            #region Instantiate-SDK

            if (!string_null_or_empty(email) && !string_null_or_empty(password))
            {
                #region Credentials
                
                slidepay = new SlidePayWindowsSDK("email", email, password, debug_output, proxy_url);

                #endregion

                #region Find-Endpoint

                if (slidepay.sp_find_endpoint()) Console.WriteLine("Found endpoint: " + slidepay._endpoint_url);
                else exit_application("Could not find an endpoint for email " + email);

                #endregion

                #region Login

                if (slidepay.sp_login()) Console.WriteLine("Successfully authenticated");
                else exit_application("Unable to authenticate");

                #endregion

                #region Get-Token-Details

                if (slidepay.sp_token_detail()) Console.WriteLine("Successfully retrieved token details");
                else exit_application("Could not retrieve token details");

                #endregion
            }
            else if (!string_null_or_empty(api_key) && !string_null_or_empty(endpoint))
            {
                #region API-Key-and-Endpoint
                
                slidepay = new SlidePayWindowsSDK("api_key", api_key, endpoint, debug_output, proxy_url);

                #endregion

                #region Get-Token-Details

                if (slidepay.sp_token_detail()) Console.WriteLine("Successfully retrieved token details");
                else exit_application("Could not retrieve token details");

                #endregion
            }
            else if (!string_null_or_empty(token) && !string_null_or_empty(endpoint))
            {
                #region Token-and-Endpoint
                
                slidepay = new SlidePayWindowsSDK("token", token, endpoint, debug_output, proxy_url);

                #endregion

                #region Get-Token-Details

                if (slidepay.sp_token_detail()) Console.WriteLine("Successfully retrieved token details");
                else exit_application("Could not retrieve token details");

                #endregion
            }
            else
            {
                exit_application("Authentication material not set.");
                return;
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

                    case "? ach":
                        menu_ach();
                        break;

                    case "? authorization":
                        menu_authorization();
                        break;

                    case "? bank_account":
                        menu_bank_account();
                        break;

                    case "? payment":
                        menu_payment();
                        break;

                    case "? stored_payment":
                        menu_stored_payment();
                        break;

                    case "? report":
                        menu_report();
                        break;

                    case "q":
                        run_forever = false;
                        break;

                    case "config":
                        display_config(slidepay);
                        break;

                    case "find_endpoint":
                        if (slidepay.sp_find_endpoint()) Console.WriteLine("Found endpoint: " + slidepay._endpoint_url);
                        else exit_application("Could not find an endpoint for email " + email);
                        break;

                    case "authenticate":
                        slidepay.sp_reset();
                        set_auth_parameters(out email, out password, out proxy_url, out api_key, out endpoint, out token, out debug_output);
                        if (slidepay.sp_login()) Console.WriteLine("Successfully authenticated");
                        else exit_application("Unable to authenticate");
                        break;

                    case "token detail":
                        if (token_detail()) Console.WriteLine("Successfully retrieve token details");
                        else exit_application("Could not retrieve token details");
                        break;

                    #endregion

                    #region Authorization
                     
                    case "key_authorization":
                        if (key_authorization()) Console.WriteLine("Authorization request succeeded.");
                        else Console.WriteLine("Authorization request failed.");
                        break;

                    case "track1_authorization":
                        if (track1_authorization()) Console.WriteLine("Authorization request succeeded.");
                        else Console.WriteLine("Authorization request failed.");
                        break;

                    case "track2_authorization":
                        if (track2_authorization()) Console.WriteLine("Authorization request succeeded.");
                        else Console.WriteLine("Authorization request failed.");
                        break;

                    case "void_authorization":
                        if (void_authorization()) Console.WriteLine("Void request succeeded.");
                        else Console.WriteLine("Void request failed.");
                        break;

                    case "get_authorization":
                        if (get_authorization()) Console.WriteLine("Authorization retrieval request succeeded.");
                        else Console.WriteLine("Authorization retrieval request failed.");
                        break;

                    case "get_all_authorizations":
                        if (get_all_authorizations()) Console.WriteLine("Authorization retrieval request succeeded.");
                        else Console.WriteLine("Authorization retrieval request failed.");
                        break;

                    case "search_authorizations":
                        if (put_authorization()) Console.WriteLine("Authorization search request succeeded.");
                        else Console.WriteLine("Authorization search request failed.");
                        break;

                    #endregion

                    #region Payment

                    case "key_payment":
                        if (key_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "stored_payment":
                        if (stored_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "track1_payment":
                        if (track1_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "track2_payment":
                        if (track2_payment()) Console.WriteLine("Payment request succeeded.");
                        else Console.WriteLine("Payment request failed.");
                        break;

                    case "refund_payment":
                        if (refund_payment()) Console.WriteLine("Refund request succeeded.");
                        else Console.WriteLine("Refund request failed.");
                        break;

                    case "get_payment":
                        if (get_payment()) Console.WriteLine("Payment retrieval request succeeded.");
                        else Console.WriteLine("Payment retrieval request failed.");
                        break;

                    case "get_all_payments":
                        if (get_all_payments()) Console.WriteLine("Payment retrieval request succeeded.");
                        else Console.WriteLine("Payment retrieval request failed.");
                        break;

                    case "search_payments":
                        if (put_payment()) Console.WriteLine("Payment search request succeeded.");
                        else Console.WriteLine("Payment search request failed.");
                        break;

                    #endregion

                    #region Stored-Payment

                    case "create_stored_payment":
                        if (create_stored_payment()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    case "get_stored_payment":
                        if (get_stored_payment()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    case "get_all_stored_payments":
                        if (get_all_stored_payments()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    case "delete_stored_payment":
                        if (del_stored_payment()) Console.WriteLine("Stored payment request succeeded.");
                        else Console.WriteLine("Stored payment request failed.");
                        break;

                    #endregion

                    #region Bank-Account

                    case "get_bank_account":
                        if (get_bank_account()) Console.WriteLine("Bank account retrieval request succeeded.");
                        else Console.WriteLine("Bank account retrieval request failed.");
                        break;
                        
                    case "get_all_bank_accounts":
                        if (get_all_bank_accounts()) Console.WriteLine("Bank account retrieval request succeeded.");
                        else Console.WriteLine("Bank account retrieval request failed.");
                        break;
                        
                    case "del_bank_account":
                        if (del_bank_account()) Console.WriteLine("Bank account delete request succeeded.");
                        else Console.WriteLine("Bank account delete request failed.");
                        break;
                        
                    case "create_bank_account":
                        if (create_bank_account()) Console.WriteLine("Bank account creation request succeeded.");
                        else Console.WriteLine("Bank account creation request failed.");
                        break;

                    #endregion

                    #region ACH

                    case "ach_balance":
                        if (post_ach_balance()) Console.WriteLine("ACH balance retrieval request succeeded.");
                        else Console.WriteLine("ACH balance retrieval request failed.");
                        break;

                    case "ach_settlement":
                        if (post_ach_settlement()) Console.WriteLine("ACH settlement request succeeded.");
                        else Console.WriteLine("ACH settlement request failed.");
                        break;

                    case "ach_retrieval":
                        if (post_ach_retrieval()) Console.WriteLine("ACH retrieval request succeeded.");
                        else Console.WriteLine("ACH retrieval request failed.");
                        break;

                    #endregion

                    #region Report

                    case "payment_report":
                        if (post_payment_report()) Console.WriteLine("Payment report retrieval request succeeded.");
                        else Console.WriteLine("Payment report retrieval request failed.");
                        break;

                    case "account_report":
                        if (post_account_report()) Console.WriteLine("Account report retrieval request succeeded.");
                        else Console.WriteLine("Payment report retrieval request failed.");
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
