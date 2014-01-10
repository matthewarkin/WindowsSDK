using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public bool sp_token_detail()
        {
            #region Check-for-Null-Values
            
            if (string_null_or_empty(_endpoint_url))
            {
                log("sp_token_detail null value detected for endpoint URL", true);
                return false;
            }

            #endregion

            #region Variables

            rest_response login_rest_resp = new rest_response();
            response login_resp = new response();

            rest_response detail_rest_resp = new rest_response();
            response detail_resp = new response();

            #endregion

            #region Retrieve-Token-Details

            detail_rest_resp = rest_client<string>(
                _endpoint_url + "token/detail",
                "GET",
                null,
                null);

            if (detail_rest_resp == null)
            {
                log("sp_token_detail null response from rest_client for token detail call", true);
                return false;
            }

            if (detail_rest_resp.status_code != 200)
            {
                log("sp_token_detail rest_client returned status other than 200 for token detail call", true);
                return false;
            }

            try
            {
                detail_resp = deserialize_json<response>(detail_rest_resp.output_body_string);
            }
            catch (Exception)
            {
                log("sp_token_detail unable to deserialize response from server for token detail call", true);
                return false;
            }

            if (!detail_resp.success)
            {
                log("sp_token_detail success false returned from server for token detail call", true);
                return false;
            }

            try
            {
                log("sp_token_detail retrieved token detail: " + detail_resp.data.ToString());
                _token = deserialize_json<token>(detail_resp.data.ToString());
                _token_created = DateTime.Now;
                log("sp_token_detail token detail retrieved");
            }
            catch (Exception)
            {
                log("sp_token_detail unable to deserialize token detail", true);
                return false;
            }

            #endregion

            #region Enumerate

            log("===============================================================================");
            log("Token details retrieved: ");
            log("  created: " + _token_created);
            log("  server_name: " + _token.server_name);
            log("  endpoint: " + _token.endpoint);
            log("  email: " + _token.email);
            log("  ip_address: " + _token.ip_address);
            log("  company_id: " + _token.company_id + " " + _token.company_name);
            log("  location_id: " + _token.location_id + " " + _token.location_name);
            log("  user_master_id: " + _token.user_master_id + " " + _token.first_name + " " + _token.last_name);
            log("===============================================================================");

            #endregion

            return true;
        }
    }
}
