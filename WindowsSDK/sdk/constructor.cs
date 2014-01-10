using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public SlidePayWindowsSDK(string auth, string param1, string param2, bool debug_output, string proxy_url)
        {
            switch (auth)
            {
                case "email":
                    _email = param1;
                    _password = param2;
                    _debug_output = debug_output;
                    _proxy_url = proxy_url;
                    _api_key = "";
                    _token_string = "";
                    _endpoint_url = "";
                    _debug_output = debug_output;
                    log_sdk_init();
                    break;

                case "api_key":
                    _email = "";
                    _password = "";
                    _debug_output = debug_output;
                    _proxy_url = proxy_url;
                    _api_key = param1;
                    _token_string = "";
                    _endpoint_url = param2;
                    _debug_output = debug_output;
                    log_sdk_init();break;

                case "token":
                    _email = "";
                    _password = "";
                    _debug_output = debug_output;
                    _proxy_url = proxy_url;
                    _api_key = "";
                    _token_string = param1;
                    _endpoint_url = param2;
                    _debug_output = debug_output;
                    log_sdk_init();
                    break;
            }
        }
    }
}
