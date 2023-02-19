using System;

namespace enumExample
{
    class WeatherApp
    {
        static void Main(string[] args)
        {
            Console.Write("Lütfen bir gün giriniz: ");
            String ourDay = Console.ReadLine();
            ourDay = ourDay.ToLower();
            Console.WriteLine("Seçilen gün: " + ourDay);

            switch(ourDay)
            {
                case "monday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.monday);
                    break;
                case "tuesday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.tuesday);
                    break;
                case "wednesday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.wednesday);
                    break;
                case "thursday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.thursday);
                    break;
                case "friday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.friday);
                    break;
                case "saturday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.saturday);
                    break;
                case "sunday":
                    Console.WriteLine("Hava Sıcaklığı: " + (int)Days.sunday);
                    break;
                default:
                    Console.WriteLine("Geçersiz işlem ");
                    break;

            }


        }
    }

   
    enum Days
    {
        monday=37,
        tuesday=23,
        wednesday=14,
        thursday=33,
        friday=-4,
        saturday=27,
        sunday=3
    }
}
