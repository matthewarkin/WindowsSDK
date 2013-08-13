using System;
using System.Net;
using System.Diagnostics;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void exception(string method, string text, Exception e)
        {
            #region Get-Line-Number

            var st = new StackTrace(e, true);
            var frame = st.GetFrame(0);
            int line = frame.GetFileLineNumber();
            string filename = frame.GetFileName();

            #endregion

            #region Send-Log-Details

            log("===============================================================================", true);
            log("Exception encountered", true);
            log("", true);
            log("  Type: " + e.GetType().ToString(), true);
            log("  Text: " + text, true);
            log("  Data: " + e.Data, true);
            log("  Inner: " + e.InnerException, true);
            log("  Message: " + e.Message, true);
            log("  Source: " + e.Source, true);
            log("  StackTrace: " + e.StackTrace, true);
            log("  Line: " + line, true);
            log("  File: " + filename, true);
            log("  ToString: " + e.ToString(), true);
            log("===============================================================================", true);

            #endregion

            return;
        }
    }
}
