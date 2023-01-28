using System;

namespace ourProgress
{
    class ourProgram
    {
        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());
            Console.WriteLine(count);
            String[] ourString = new string[count];
            for (int i = 0; i < count; i++)
            {
                ourString[i] = Console.ReadLine();
            }
            for (int i = 0; i < count; i++)
            {
                ourNewWord(ourString[i]);
            }


        }

        static void ourNewWord(string word)
        {
            string ourString1 = "";
            string ourString2 = "";
            for (int i = 0; i < word.Length; i++)
            {
                if (i % 2 == 0)
                {
                    ourString1 += word[i];
                }
                else
                {
                    ourString2 += word[i];
                }
            }
            Console.WriteLine(ourString1 + " " + ourString2);
        }
    }

}
