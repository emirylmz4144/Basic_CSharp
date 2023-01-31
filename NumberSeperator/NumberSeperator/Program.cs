using System;
using System.Collections;

namespace Examples
{
    class ourExamples
    {
        static void Main(string[] args)
        {
            int[] ourMainInteger = new int[20];


            ArrayList prime = new ArrayList();
            ArrayList nonPrime = new ArrayList();

            for (int i = 0; i < ourMainInteger.Length; i++)
            {
                int counter = 0;
                Console.Write("Dizinin " + (i + 1) + ".elemanını giriniz: ");
                int value = int.Parse(Console.ReadLine());
                while (value < 0)
                {
                    Console.Write("0 dan büyük sayı giriniz: ");
                    value = int.Parse(Console.ReadLine());
                }



                ourMainInteger[i] = value;

                for (int j = 1; j <= value; j++)
                {
                    if (value % j == 0)
                    {
                        counter++;
                    }
                }


                if (counter > 2)
                {
                    nonPrime.Add(value);
                }
                else
                {
                    prime.Add(value);
                }

            }


            prime.Sort();
            nonPrime.Sort();

            int result = 0;
            Console.Write("Asal sayılar: ");
            foreach (int i in prime)
            {

                Console.Write(i + " , ");
                result += i;
            }
            Console.WriteLine();
            Console.WriteLine("Asal sayıların ortalaması: " + result / prime.Count + " miktarı " + prime.Count);
            result = 0;

            Console.Write("Asal olmaya sayılar: ");
            foreach (int i in nonPrime)
            {

                Console.Write(i + " , ");
                result += i;
            }
            Console.WriteLine();
            Console.WriteLine("Asal olmayan sayıların ortalaması: " + result / nonPrime.Count + " miktarı " + nonPrime.Count);



        }
    }
}