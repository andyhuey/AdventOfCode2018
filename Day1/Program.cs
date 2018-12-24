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
            var lines = File.ReadAllLines(@"..\..\input2.txt");
            int hasTwo = 0, hasThree = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                Dictionary<char, int> letterFreq = new Dictionary<char, int>();
                foreach (char letter in lines[i])
                {
                    if (letterFreq.ContainsKey(letter))
                        letterFreq[letter] += 1;
                    else
                        letterFreq.Add(letter, 1);
                }
                if (letterFreq.ContainsValue(2))
                    hasTwo++;
                if (letterFreq.ContainsValue(3))
                    hasThree++;
            }

            Console.WriteLine("has 2: {0}, has 3: {1}, checksum: {2}", hasTwo, hasThree, hasTwo * hasThree);
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }

        static void Day1()
        {
            var lines = File.ReadAllLines(@"..\..\input1.txt");
            int freq = 0;
            HashSet<int> seenFreqs = new HashSet<int>();
            bool found = false;
            int timesThru = 0;

            while (!found)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    seenFreqs.Add(freq);
                    string chg = lines[i];
                    if (!string.IsNullOrEmpty(chg))
                    {
                        freq += int.Parse(chg);
                        if (seenFreqs.Contains(freq))
                        {
                            Console.WriteLine("Frequency {0} is first seen twice.", freq);
                            found = true;
                            break;
                        }
                    }
                }
                Console.WriteLine("times thru input: {0}", ++timesThru);
            }
            //Console.WriteLine("Frequency: {0}", freq);
        }
    }
}
