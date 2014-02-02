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
        public List<payment> sp_get_authorization(int authorization_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_get_authorization null value detected for token, please authenticate", true);
                return null;
            }

            if (authorization_id <= 0)
            {
                log("sp_get_authorization authorization_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response get_authorization_rest_resp = new rest_response();
            response get_authorization_resp = new response();
            List<payment> curr_authorization_list = new List<payment>();

            #endregion
            
            #region Process-Request

            get_authorization_rest_resp = rest_client<payment>(
                _endpoint_url + "payment/" + authorization_id + "?auto_capture=0",
                "GET",
                null,
                null);

            if (get_authorization_rest_resp == null)
            {
                log("sp_get_authorization null response from rest_client for authorization retrieval call", true);
                return null;
            }

            if (get_authorization_rest_resp.status_code != 200)
            {
                log("sp_get_authorization rest_client returned status other than 200 for authorization retrieval call", true);
                return null;
            }

            try
            {
                get_authorization_resp = deserialize_json<response>(get_authorization_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_get_authorization unable to deserialize response from server for authorization retrieval call", true);
                return null;
            }

            if (!get_authorization_resp.success)
            {
                log("sp_get_authorization success false returned from server for authorization retrieval call", true);
                return null;
            }

            try
            {
                curr_authorization_list = deserialize_json<List<payment>>(get_authorization_resp.data.ToString());
                log("sp_get_authorization response retrieved");
            }
            catch (Exception)
            {
                log("sp_get_authorization unable to deserialize authorization list object", true);
                return null;
            }

            if (curr_authorization_list == null)
            {
                log("sp_get_authorization null authorization list retrieved", true);
                return null;
            }

            if (curr_authorization_list.Count < 1)
            {
                log("sp_get_authorization no authorizations retrieved", true);
                return null;
            }

            #endregion

            #region Enumerate

            foreach (payment curr_authorization in curr_authorization_list)
            {
                log("===============================================================================");
                log("Authorization retrieved: payment_id " + curr_authorization.payment_id);
                log("  " + curr_authorization.method + " " + curr_authorization.cc_type + " " + curr_authorization.cc_redacted_number + " " + curr_authorization.cc_expiry_month + "/" + curr_authorization.cc_expiry_year + " " + decimal_tostring(curr_authorization.amount));
                log("  Approval " + curr_authorization.provider_approval_code + " Status " + curr_authorization.provider_status_code + " " + curr_authorization.provider_status_message + " " + curr_authorization.provider_transaction_state);
                log("  Response time " + curr_authorization.processor_time_ms + "ms");
                log("  Stored Payment GUID " + curr_authorization.stored_payment_guid);
                log("===============================================================================");
            }

            #endregion

            return curr_authorization_list;
        }
    }
}
