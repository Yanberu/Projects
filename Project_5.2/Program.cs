using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_5._2
{
    internal class Program
    {
        static string[] TextSplit(string text)

        {
            string[] textSplit = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return textSplit;
        }


        static string ReverseString(string text)
        {
            string[] result = TextSplit(text);
            string resultString = "";
            for (int i = result.Length - 1; i >= 0 ; i--)
            {
                resultString += result[i] + " ";
            }
            return resultString;
        }

        static void OutputWords(string resultString)
        {
            
            Console.WriteLine(resultString);
        }

        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string resultString = ReverseString(text);
            OutputWords(resultString);
            Console.ReadLine();
        }
    }
}



