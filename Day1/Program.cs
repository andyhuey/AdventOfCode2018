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

            for (int i = 0; i < lines.Length; i++)
                for (int j = i + 1; j < lines.Length; j++)
                {
                    string box1 = lines[i];
                    string box2 = lines[j];
                    int pos = 0, diffs = 0;
                    while (diffs <= 1 && pos < box1.Length && pos < box2.Length)
                    {
                        if (box1[pos] != box2[pos])
                            diffs++;
                        pos++;
                    }
                    if (diffs == 1)
                    {
                        Console.WriteLine("box1: {0}", box1);
                        Console.WriteLine("box2: {0}", box2);
                        Console.Write("common letters: ");
                        pos = 0;
                        while (pos < box1.Length)
                        {
                            if (box1[pos] == box2[pos])
                                Console.Write(box1[pos]);
                            pos++;
                        }
                        Console.WriteLine();
                        break;
                    }
                }
            /*  box1: mkucdflathzwsvjxrevymbdpoq
                box2: mkwcdflathzwsvjxrevymbdpoq
                common letters: mkcdflathzwsvjxrevymbdpoq
            */
            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }

        static void Day2a()
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
