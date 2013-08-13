using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void log(string message, bool warning)
        {
            if (warning) log("*** " + message);
        }

        public static void log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
