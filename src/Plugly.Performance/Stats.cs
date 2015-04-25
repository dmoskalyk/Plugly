using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Performance
{
    class Stats
    {
        public long DefaultCreate;
        public long ProxyCreate;
        public long DefaultCall;
        public long ProxyCall;

        public void Print()
        {
            Console.WriteLine();
            PrintLine(string.Empty, "Default", "Plugly");
            PrintLine("Create", DefaultCreate, ProxyCreate);
            PrintLine("GetText", DefaultCall, ProxyCall);
            Console.WriteLine("\nHit Enter to exit...");
            Console.ReadLine();
        }

        void PrintLine(string name, long value1, long value2)
        {
            PrintLine(name, value1.ToString() + "ms", value2.ToString() + "ms");
        }

        void PrintLine(string name, string value1, string value2)
        {
            PrintCell(name); PrintCell(value1); PrintCell(value2); Console.WriteLine();
        }

        void PrintCell(string value)
        {
            Console.Write(value);
            Console.Write(new string('\t', 2 - value.Length / 8));
        }
    }
}
