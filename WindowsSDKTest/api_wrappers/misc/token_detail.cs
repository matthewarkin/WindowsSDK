using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsSDK;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static bool token_detail()
        {
            if (slidepay.sp_token_detail())
            {
                Console.WriteLine("===============================================================================");
                Console.WriteLine("Token details retrieved: ");
                Console.WriteLine("  created: " + slidepay._token.created);
                Console.WriteLine("  server_name: " + slidepay._token.server_name);
                Console.WriteLine("  endpoint: " + slidepay._token.endpoint);
                Console.WriteLine("  email: " + slidepay._token.email);
                Console.WriteLine("  ip_address: " + slidepay._token.ip_address);
                Console.WriteLine("  company_id: " + slidepay._token.company_id + " " + slidepay._token.company_name);
                Console.WriteLine("  location_id: " + slidepay._token.location_id + " " + slidepay._token.location_name);
                Console.WriteLine("  user_master_id: " + slidepay._token.user_master_id + " " + slidepay._token.first_name + " " + slidepay._token.last_name);
                Console.WriteLine("===============================================================================");

                return true;
            }
            else
            {
                Console.WriteLine("Unable to retrieve token detail.");
                return false;
            }
        }
    }
}
