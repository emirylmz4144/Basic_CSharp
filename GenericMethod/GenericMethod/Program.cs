using System;
namespace ourProgress
{
    class Printer
    {
        static void Main(string[] args)
        {
            Console.Write("Lütfen kaç elemanlı dizi gireceğinizi yazınız: ");
            
            int count = Convert.ToInt32(Console.ReadLine());
            int[] intArray = new int[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("Lütfen dizinin "+(i+1)+".elemanını giriniz: ");
                intArray[i] = Convert.ToInt32(Console.ReadLine());
            }

            count = Convert.ToInt32(Console.ReadLine());
            string[] stringArray = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write("Lütfen dizinin " + (i + 1) + ".elemanını giriniz: ");
                stringArray[i] = Console.ReadLine();
            }

            PrintArray<String>(stringArray);
            PrintArray<Int32>(intArray);

        }

        static void PrintArray<T>(T[] ourArray)
        {
            foreach (T t in ourArray)
            {
                Console.WriteLine(t);
            }
        }
    }
}




