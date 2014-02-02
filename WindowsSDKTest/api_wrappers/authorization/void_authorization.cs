using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool void_authorization()
        {
            #region Variables

            int authorization_id = 0;
            object resp = new object();

            #endregion

            #region Populate-Variables

            Console.Write("Payment ID: ");
            try
            {
                authorization_id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to convert authorization ID from string to integer.");
                return false;
            }

            #endregion

            #region Check-for-Null-or-Bad-Values

            if (authorization_id <= 0)
            {
                Console.WriteLine("Payment ID must be greater than zero.");
                return false;
            }

            #endregion

            #region Process-Request

            resp = slidepay.sp_void_authorization(authorization_id);

            if (resp == null)
            {
                Console.WriteLine("Null response for refund request.");
                return false;
            }

            if (resp is List<processor_cc_txn_response>)
            {
                if ((List<processor_cc_txn_response>)resp != null)
                {
                    if (((List<processor_cc_txn_response>)resp).Count > 0)
                    {
                        foreach (processor_cc_txn_response curr in (List<processor_cc_txn_response>)resp)
                        {
                            Console.WriteLine("===============================================================================");
                            Console.WriteLine("Authorization void response received: " + curr.is_approved);
                            Console.WriteLine("  " + curr.cc_type + " " + curr.cc_redacted_number + " " + curr.cc_expiry_month + "/" + curr.cc_expiry_year + " " + decimal_tostring(curr.amount));
                            Console.WriteLine("  Approval " + curr.approval_code + " Status " + curr.status_code + " " + curr.status_message + " " + curr.transaction_state);
                            Console.WriteLine("  Response time " + curr.processor_time_ms + "ms");

                            if (curr.is_approved)
                            {
                                Console.WriteLine("  Payment ID " + curr.payment_id);
                                Console.WriteLine("  Stored Payment GUID " + curr.stored_payment_guid);
                            }

                            Console.WriteLine("===============================================================================");
                        }
                    }
                    else
                    {
                        log("===============================================================================");
                        log("Empty processor response list");
                        log("===============================================================================");
                    }
                }
                else
                {
                    log("===============================================================================");
                    log("Null processor response list");
                    log("===============================================================================");
                }
            }
            else if (resp is error_message)
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Error: " + ((error_message)resp).error_code + " " + ((error_message)resp).error_file + " " + ((error_message)resp).error_text);
                Console.WriteLine("===============================================================================");
                return false;
            }
            else
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Null response received");
                Console.WriteLine("===============================================================================");
                return false;
            }

            #endregion

            return true;
        }
    }
}
