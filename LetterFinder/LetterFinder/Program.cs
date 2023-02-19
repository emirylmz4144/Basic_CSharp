using System;

namespace LetterFinder
{
    class Finder
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir cümle giriniz");
            string sentence = Console.ReadLine();

            wowels(sentence);
            wowelsQuality(sentence); 
     
        }

        static void wowels(string sentence)
        {
            char[] letterArray = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
            string ourWowels = "";

            foreach (char letter in sentence)
            {
                if (Array.IndexOf(letterArray, letter) != -1)
                {
                    ourWowels += letter;
                }
            }
            char[] sortingWowels = ourWowels.ToCharArray();
            Array.Sort(sortingWowels);

            Console.WriteLine(sortingWowels);
        }



        static void wowelsQuality(string sentence)
        {
            char[] letterArray = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };
            int[] wowelsQuality = new int[letterArray.Length];

            for(int i=0;i<letterArray.Length;i++)
            {
                for(int j=0;j<sentence.Length;j++)
                {
                    if (letterArray[i] == sentence[j])
                    {
                        wowelsQuality[i]++;
                    }
                }
            }

            for(int i=0;i<letterArray.Length;i++)
            {
                if (wowelsQuality[i]==0)
                {
                    continue;
                }
                Console.WriteLine(letterArray[i] + " harfinden " + wowelsQuality[i] + " adet bulunmaktadır");
            }

        }
    }
}
