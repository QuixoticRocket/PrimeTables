using PrimeNumberLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please supply n (n must be greater than 0):");
            string input = Console.ReadLine();
            int n = 0;

            int.TryParse(input, out n);

            while (n < 1)
            {
                Console.WriteLine("Sorry. Couldn't parse that number or it was less than 1");
                Console.WriteLine("Please supply n (n must be greater than 0):");
                input = Console.ReadLine();
                int.TryParse(input, out n);
            }

            PrimeNumberEngine engine = new PrimeNumberEngine();
            int?[,] output = engine.GenerateTable((uint)n);

            //output

            Console.WriteLine();

            int maxstringlength = 0;

            //just to make display nice we need to find maximum string length
            for (int x = 0; x < n + 1; x++)
            {
                for (int y = 0; y < n + 1; y++)
                {
                    if (output[x, y].HasValue)
                    {
                        string tempstring = output[x, y].ToString();
                        maxstringlength = tempstring.Length > maxstringlength ? tempstring.Length : maxstringlength;
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            char seperator = '|';
            char space = ' ';

            for (int x = 0; x < n + 1; x++)
            {
                for (int y = 0; y < n + 1; y++)
                {
                    sb.Append(PaddedString(output[x, y], maxstringlength, space));
                    sb.Append(seperator);
                }
                sb.Append(Environment.NewLine);
            }

            Console.Write(sb.ToString());

            Console.WriteLine();
            Console.WriteLine("please press any key to exit");
            Console.ReadKey();
        }

        private static string PaddedString(int? v, int maxstringlength, char spacerChar)
        {
            int pad = 2 + (maxstringlength % 2); //variable padding to keep the string an even number
            char[] charArray = new char[maxstringlength + pad];
            int midpoint = (maxstringlength + 2) / 2;
            string numberAsText = v.HasValue ? v.Value.ToString() : string.Empty;
            int textlength = numberAsText.Length;

            int prepadlength = (maxstringlength + pad - textlength) / 2;

            for (int i = 0; i < maxstringlength + pad; i++)
            {
                if (i < prepadlength || i >= prepadlength + textlength)
                {
                    charArray[i] = spacerChar;
                }
                else
                {
                    charArray[i] = numberAsText[i - prepadlength];
                }
            }

            return new string(charArray);
        }
    }
}
