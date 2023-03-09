using System;

namespace ConsonantsNextTo

{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen bir metin giriniz: ");
            string text= Console.ReadLine();

            bool[] allWordsStatus = ConvertorClass.returnTheStatus(text.Split(" "));//metni kelimelere ayırırız

            for (int i = 0; i < allWordsStatus.Length; i++)
            {
                Console.Write(allWordsStatus[i]+" ");
            }

        }
    }
}

