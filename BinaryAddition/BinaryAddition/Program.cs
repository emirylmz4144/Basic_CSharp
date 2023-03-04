using System;
using System.Collections;

namespace BinaryAddition
{
    public class Addition
    {
        static void Main(string[] args)
        {
            List<int> ourList=new List<int>();
            Console.WriteLine("<C>ıkıs yapana kadar sayı giriniz: ");
            while(true)
            {
                var value = Console.ReadLine();
                int ourİntValue;
                if(int.TryParse(value,out ourİntValue))
                {
                    ourList.Add(ourİntValue);
                }
                else
                {
                    if (value.Equals("c") || value.Equals("C"))
                        break;
                    else
                        Console.WriteLine("Lütfen geçeerli bir işlem yapınız:");
                }
            }

            for(int i=0;i<ourList.Count;i+=2)
            {
                Console.WriteLine((ourList[i] + ourList[i+1]));
            }
            Console.ReadKey();
        }
    }
}
