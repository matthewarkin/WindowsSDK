using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        #region Class-Variables

        public static SlidePayWindowsSDK slidepay;
        public static string _version = "v1.0.1";
        public enum auth_type
        {
            email,
            api_key,
            token
        }

        #endregion
    }
}
