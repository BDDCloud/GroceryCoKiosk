using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GroceryCo.Kiosk.Console
{
    public interface IConsoleWriter
    {
        void WriteLine(string line);
    }
}
