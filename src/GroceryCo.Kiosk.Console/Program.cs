using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var cartFile = args[0];
            var productCatalogFile = args[1];

            var items = File.ReadAllLines(cartFile);
            if (items.Length == 0)
            {
                System.Console.WriteLine("Error cart is empty");
                return;
            }
        }
    }
}
