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
        public object sp_capture_auth_convert(int payment_id)
        {
            #region Check-for-Null-Values

            if (string_null_or_empty(_token_string))
            {
                log("sp_capture_auth_convert null value detected for token, please authenticate", true);
                return null;
            }

            if (payment_id <= 0)
            {
                log("sp_capture_auth_convert payment_id must be greater than zero", true);
                return null;
            }

            #endregion

            #region Variables

            rest_response capture_rest_resp = new rest_response();
            response capture_resp = new response();
            error_message error = new error_message();

            #endregion
            
            #region Process-Request

            capture_rest_resp = rest_client<simple_payment>(
                _endpoint_url + "capture/auto/" + payment_id,
                "POST",
                null,
                null);

            if (capture_rest_resp == null)
            {
                log("sp_capture_auth_convert null response from rest_client for capture call", true);
                return null;
            }

            if (capture_rest_resp.status_code != 200 &&
                capture_rest_resp.status_code != 201)
            {
                log("sp_capture_auth_convert rest_client returned status other than 200/201 for capture call", true);
                return null;
            }

            try
            {
                capture_resp = deserialize_json<response>(capture_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_capture_auth_convert unable to deserialize response from server for capture call", true);
                return null;
            }

            if (!capture_resp.success)
            {
                log("sp_capture_auth_convert success false returned from server for capture call", true);

                try
                {
                    error = deserialize_json<error_message>(capture_resp.data.ToString());
                    log("sp_capture_auth_convert error_message detected: " + error.error_code + " " + error.error_file + " " + error.error_text);
                    return error;
                }
                catch (Exception)
                {
                    log("sp_capture_auth_convert could not deserialize as processor_cc_txn_response or error_message, returning null");
                    return null;
                }
            }
            else
            {
                log("sp_capture_auth_convert success true returned from server for capture call", false);
                return true;
            }

            #endregion
        }
    }
}
