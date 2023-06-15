﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project_5
{
   
    internal class Program
    {
        static string[] TextSplit(string text)

        {
            string[] textSplit = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return textSplit;
        }

        static void OutputWords(string[] result) 
        {
            string resultString = "";
            for (int i = 0; i <= result.Length - 1; i++)
            {
                resultString += result[i] + " ";
            }
            Console.WriteLine(resultString);
        }

        static void Main(string[] args)
        {

            string text = Console.ReadLine();
            string[] result = TextSplit(text);
            OutputWords(result);
            Console.ReadLine();
        }
    }
}

