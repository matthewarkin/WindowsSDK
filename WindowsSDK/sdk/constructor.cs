using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        public SlidePayWindowsSDK(string email, string password)
        {
            _email = email;
            _password = password;
            _debug_output = false;

            _use_proxy = false;
            _proxy_url = "";
            _accept_invalid_ssl_certificates = false;

            log_sdk_init();
        }

        public SlidePayWindowsSDK(string email, string password, bool debug_output)
        {
            _email = email;
            _password = password;
            _debug_output = debug_output;

            _use_proxy = false;
            _proxy_url = "";
            _accept_invalid_ssl_certificates = false;

            log_sdk_init();
        }

        public SlidePayWindowsSDK(string email, string password, bool debug_output, bool use_proxy, string proxy_url)
        {
            _email = email;
            _password = password;
            _debug_output = true;

            _use_proxy = false;
            _proxy_url = "";
            _accept_invalid_ssl_certificates = false;

            log_sdk_init();
        }
    }
}
