using System;

namespace absoluteSquaring
{
    public class Squaring
    {
        static void Main(string[] args)
        {
            
            List<int> ourList=new List<int>();

            Console.WriteLine("<C>ıkıs yapana kadar sayı gireceksiniz:");

            while (true)
            {
                var value = Console.ReadLine();
                if (!value.Equals("c") || value.Equals("C"))
                {
                    int ourIntValue;
                    if (!int.TryParse(value, out ourIntValue))
                        Console.WriteLine("Lütfen geçerli bir işlen yapınız..");

                    else
                    {
                        ourList.Add(ourIntValue);
                        Console.WriteLine("sayı eklendi: "+ ourIntValue);
                    }
                }
                else
                    break;

            }

            int resultOfPlus = 0;
            int resultOfMinus = 0;

            for(int i=0;i<ourList.Count;i++) 
            {
                if (ourList[i]<67)
                    resultOfMinus += 67 - ourList[i];
                else
                    resultOfPlus += Math.Abs(67 - ourList[i])* Math.Abs(67 - ourList[i]);

            }

            Console.WriteLine("67 den küçük olan sayıların farklarının toplamı : " + resultOfMinus);
            Console.WriteLine("67 den büyük olan sayıların farkların mutlak karelerinin toplamı : " + resultOfPlus);

        }

     }
 }
