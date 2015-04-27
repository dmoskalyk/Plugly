using Plugly.Performance.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugly.Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            bool warmup = true;

            var count = ReadIterationCount();
            var stats = new Stats();
            var customizer = Customizer.Current;
            if (warmup)
                customizer.CreateInstance<Address>();
            var watch = Stopwatch.StartNew();
            for (int i = 0; i < count; i++)
            {
                var o = new Address();
            }
            stats.DefaultCreate = watch.ElapsedMilliseconds;
            watch.Restart();
            for (int i = 0; i < count; i++)
            {
                var o = customizer.CreateInstance<Address>();
            }
            stats.ProxyCreate = watch.ElapsedMilliseconds;

            customizer.Setup<Address>()
                .ExtendWith<PhoneNumberExtension>()
                .ExtendWith<StreetExtension>()
                ;
            if (warmup)
                customizer.CreateInstance<Address>();

            var a1 = new Address();
            watch.Restart();
            for (int i = 0; i < count; i++)
                StreetExtension.AddStreet(PhoneNumberExtension.AddPhoneNumber(a1.GetText(), "phoneno"), "str");
            stats.DefaultCall = watch.ElapsedMilliseconds;
            
            var a2 = customizer.CreateInstance<Address>();
            ((IPhoneNumberExtension)a2).PhoneNumber = "no1";
            ((IStreetExtension)a2).Street = "way";
            watch.Restart();
            for (int i = 0; i < count; i++)
                a2.GetText();
            stats.ProxyCall = watch.ElapsedMilliseconds;
            
            stats.Print();
        }

        static int ReadIterationCount()
        {
            int count = 0;
            string input;
            do
            {
                Console.Write("# of iterations [default: 100000] ");
                input = Console.ReadLine();
            }
            while (!string.IsNullOrWhiteSpace(input) && (!int.TryParse(input, out count) || count <= 0));
            if (string.IsNullOrWhiteSpace(input) || count <= 0)
                count = 100000;
            return count;
        }
    }
}
