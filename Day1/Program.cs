using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    struct Claim
    {
        public int n, x, y, w, h;

        public Claim(List<string> numbers)
        {
            n = int.Parse(numbers[0]);
            x = int.Parse(numbers[1]);
            y = int.Parse(numbers[2]);
            w = int.Parse(numbers[3]);
            h = int.Parse(numbers[4]);
        }
        public override string ToString()
        {
            return string.Format("#{0} @ {1},{2}: {3}x{4}", n, x, y, w, h);
        }
    }

    struct Point
    {
        public int x, y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return string.Format("x={0}, y={1}", x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("press any key to exit.");
            Console.ReadKey();
        }

        static void Day3()
        {
            var lines = File.ReadAllLines(@"..\..\input3.txt");
            Dictionary<Point, List<Claim>> fabric = new Dictionary<Point, List<Claim>>();

            Console.WriteLine("Setting up the claim list...");
            List<Claim> allClaims = new List<Claim>();
            for (int i = 0; i < lines.Length; i++)
            {
                //if (i > 4) break;
                // input line looks like: "#n @ x,y: wxh"
                string[] output = Regex.Split(lines[i], @"\D+");
                var numbers = new List<string>(output).Where(s => !string.IsNullOrEmpty(s)).ToList();
                if (numbers.Count() != 5)
                    throw new Exception(string.Format("Expecting 5 values in string. Found {0}.", numbers.Count()));
                Claim c = new Claim(numbers);
                //Console.WriteLine(c.ToString());
                allClaims.Add(c);
            }

            Console.WriteLine("Setting up the fabric map...");
            foreach (Claim c in allClaims)
            {
                // map this claim to the fabric.
                for (int x = c.x; x < c.x + c.w; x++)
                    for (int y = c.y; y < c.y + c.h; y++)
                    {
                        // mark it.
                        Point p = new Point(x, y);
                        if (!fabric.ContainsKey(p))
                            fabric.Add(p, new List<Claim>());
                        fabric[p].Add(c);
                    }
            }

            //int overlapping_squares = fabric.Where(sq => sq.Value.Count() >= 2).Count();
            //Console.WriteLine("overlapping squares: {0}", overlapping_squares);     // 101469

            Console.WriteLine("Checking each claim for overlap...");
            foreach (Claim c in allClaims)
            {
                bool overlap = false;

                for (int x = c.x; x < c.x + c.w; x++)
                    for (int y = c.y; y < c.y + c.h; y++)
                    {
                        Point p = new Point(x, y);
                        var sq = fabric[p];
                        if (sq.Count() > 1)
                        {
                            overlap = true;
                            break;
                        }
                    }
                if (!overlap)
                {
                    Console.WriteLine("No overlap: {0}", c);    //  #1067 @ 668,880: 12x24
                    break;
                }
            }
        }

        static void Day2b()
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
