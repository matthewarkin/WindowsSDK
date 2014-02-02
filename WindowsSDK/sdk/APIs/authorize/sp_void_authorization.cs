using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public object sp_void_authorization(int payment_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_void_authorization null value detected for token, please authenticate", true);
                return null;
            }

            if (payment_id <= 0)
            {
                log("sp_void_authorization payment_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response refund_payment_rest_resp = new rest_response();
            response refund_payment_resp = new response();
            List<processor_cc_txn_response> curr_resp = new List<processor_cc_txn_response>();

            #endregion
            
            #region Process-Request

            refund_payment_rest_resp = rest_client<simple_payment>(
                _endpoint_url + "authorization/void/" + payment_id,
                "POST",
                null,
                null);

            if (refund_payment_rest_resp == null)
            {
                log("sp_void_authorization null response from rest_client for refund call", true);
                return null;
            }

            if (refund_payment_rest_resp.status_code != 200 &&
                refund_payment_rest_resp.status_code != 201)
            {
                log("sp_void_authorization rest_client returned status other than 200/201 for refund call", true);
                return null;
            }

            try
            {
                refund_payment_resp = deserialize_json<response>(refund_payment_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_void_authorization unable to deserialize response from server for refund call", true);
                return null;
            }

            if (!refund_payment_resp.success)
            {
                log("sp_void_authorization success false returned from server for refund call", true);
                return null;
            }

            try
            {
                curr_resp = deserialize_json<List<processor_cc_txn_response>>(refund_payment_resp.data.ToString());
                log("sp_void_authorization response retrieved");
            }
            catch (Exception)
            {
                log("sp_void_authorization unable to deserialize processor response", true);
                return null;
            }

            #endregion

            #region Enumerate

            if (curr_resp != null)
            {
                if (curr_resp.Count > 0)
                {
                    foreach (processor_cc_txn_response curr in curr_resp)
                    {
                        log("===============================================================================");
                        log("Authorization void response received: " + curr.is_approved);
                        log("  " + curr.cc_type + " " + curr.cc_redacted_number + " " + curr.cc_expiry_month + "/" + curr.cc_expiry_year + " " + decimal_tostring(curr.amount));
                        log("  Approval " + curr.approval_code + " Status " + curr.status_code + " " + curr.status_message + " " + curr.transaction_state);
                        log("  Response time " + curr.processor_time_ms + "ms");

                        if (curr.is_approved)
                        {
                            log("  Payment ID " + curr.payment_id);
                            log("  Stored Payment GUID " + curr.stored_payment_guid);
                        }

                        log("===============================================================================");
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

            #endregion

            return curr_resp;
        }
    }
}
