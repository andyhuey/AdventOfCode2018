using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"..\..\input.txt");
            int freq = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                string chg = lines[i];
                if (!string.IsNullOrEmpty(chg))
                    freq += int.Parse(chg);
            }
            Console.WriteLine("Frequency: {0}", freq);
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }
    }
}
