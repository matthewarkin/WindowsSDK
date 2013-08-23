using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDK
{
    public partial class SlidePayWindowsSDK
    {
        #region Class-Variables

        #region General-Variables

        private bool _debug_output = false;
        private string _proxy_url = "";
        private string _version = "v1.0.0";

        #endregion

        #region Authentication

        private string _endpoint_discovery_url = "https://supervisor.getcube.com:65532/rest.svc/API/endpoint";
        public string _endpoint_url = "";
        public string _email = "";
        public string _password = "";
        public string _token_string = "";
        private token _token;

        #endregion

        #endregion
    }
}
