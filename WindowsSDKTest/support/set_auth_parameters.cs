using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void set_auth_parameters(
            out string email, 
            out string password, 
            out string proxy_url,
            out string api_key,
            out string endpoint,
            out string token,
            out bool debug_output)
        {
            email = "";
            password = "";
            proxy_url = "";
            api_key = "";
            endpoint = "";
            token = "";
            debug_output = true;

            #region Support-Large-String-Input

            byte[] in_buffer = new byte[8192];
            Stream in_stream = Console.OpenStandardInput(in_buffer.Length);
            Console.SetIn(new StreamReader(in_stream, Console.InputEncoding, false, in_buffer.Length));

            #endregion

            #region Select-Auth-Mechanism

            string method = "";
            while (true)
            {
                Console.Write("Which authentication method?  C/credentials, A/api key, T/token: ");
                method = Console.ReadLine();

                if (String.Compare(method, "c") == 0) method = "C";
                if (String.Compare(method, "a") == 0) method = "A";
                if (String.Compare(method, "t") == 0) method = "T";
                if (String.Compare(method, "C") == 0) break;
                if (String.Compare(method, "A") == 0) break;
                if (String.Compare(method, "T") == 0) break;

                Console.WriteLine("");
                Console.WriteLine("Please choose C, A, or T.");
                Console.WriteLine("");
            }

            #endregion

            #region Gather-Auth-Material

            switch (method)
            {
                case "C":
                    while (true)
                    {
                        Console.Write("Email address: ");
                        email = Console.ReadLine();
                        Console.Write("Password: ");
                        password = Console.ReadLine();

                        if (!string_null_or_empty(email) && !string_null_or_empty(password))
                        {
                            break;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Please supply an email address and a password.");
                        Console.WriteLine("");
                    }
                    break;

                case "A":
                    while (true)
                    {
                        Console.Write("API key: ");
                        api_key = Console.ReadLine();

                        Console.WriteLine("Endpoint format: https://servername:port/rest.svc/API/");
                        Console.Write("Endpoint: ");
                        endpoint = Console.ReadLine();

                        if (!string_null_or_empty(api_key) && !string_null_or_empty(endpoint))
                        {
                            break;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Please supply an API key and endpoint.");
                        Console.WriteLine("");
                    }
                    break;

                case "T":
                    while (true)
                    {
                        Console.Write("Token: ");
                        token = Console.ReadLine();

                        Console.WriteLine("Endpoint format: https://servername:port/rest.svc/API/"); 
                        Console.Write("Endpoint: ");
                        endpoint = Console.ReadLine();

                        if (!string_null_or_empty(token) && !string_null_or_empty(endpoint))
                        {
                            break;
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Please supply an API key and endpoint.");
                        Console.WriteLine("");
                    }
                    break;
            }

            #endregion

            Console.Write("Proxy URL (example: http://127.0.0.1:8888, ENTER for none): ");
            proxy_url = Console.ReadLine();

            Console.Write("Enable debug logging (true/false)? ");
            debug_output = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("");
            Console.WriteLine("Authentication parameters set.");
        }
    }
}
