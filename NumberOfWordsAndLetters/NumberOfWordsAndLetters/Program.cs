﻿using System;

namespace NumberOfWordAndLetters
{
    class WordAndLetters
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir cümle giriniz: ");
            string ourString = Console.ReadLine();
            search(ourString);
        }
        static void search(string word)
        {
            int wordQuality=1;
            int letterQuality=0;

            for(int i=0;i<word.Length;i++)
            {
                char control = word[i];
                if(control==' ')
                {
                    wordQuality++;
                }
                else
                {
                    letterQuality++;
                }
            }
            Console.WriteLine("Kelime:" + wordQuality);
            Console.WriteLine("Harf: " + letterQuality);
        }
    }
}
