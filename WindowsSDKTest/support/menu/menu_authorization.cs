using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsSDKTest
{
    public partial class Program
    {
        public static void menu_authorization()
        {
            Console.WriteLine("===============================================================================");
            Console.WriteLine("Authorization APIs:");
            Console.WriteLine("  key_authorization       process authorization using keyed card details");
            Console.WriteLine("  track1_authorization    process authorization containing track1 data");
            Console.WriteLine("  track2_authorization    process authorization containing track2 data");
            Console.WriteLine("  void_authorization      process void for authorization by payment ID");
            Console.WriteLine("  get_authorization       retrieve authorization by ID");
            Console.WriteLine("  get_all_authorizations  retrieve all authorizations");
            Console.WriteLine("  search_authorizations   retrieve all authorizations within a date range");
            Console.WriteLine("===============================================================================");
        }
    }
}
