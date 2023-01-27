using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Migrotary
{
    class MigrotaryBirds
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(Console.ReadLine());
            int[] ourArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                //Kullanıcıdan alınan değerler diziye aktarılıyor
                int value = Convert.ToInt32(Console.ReadLine());
                ourArray[i] = value;
            }

            int[] mikrotaryBird = mikrotaryCounter(ourArray);//İlgili bilgiler ilgili fonksiyondadır.

            int maxMikrotaryCounter = 1;//en fazla tekrar eden elemanın tekrar sayısınınn atandığı değişken
            int mikrotaryCounterValue = ourArray[0];// en fazla tekrar eden elemanın atandığı değişken


            for (int i = 0; i < mikrotaryBird.Length; i++)
            {
                if (mikrotaryBird[i] > maxMikrotaryCounter)//ilgili indisdeki elemanın ne kadar tekrar ettiğini karşılaştırıyoruz
                {
                    maxMikrotaryCounter = mikrotaryBird[i];// Şart sağlandıysa tekrar sayısını yeni max tekrar eden miktarı yapıyoruz
                    mikrotaryCounterValue = ourArray[i];// ve en fazla tekrar eden elemanı ilgili değişkene atıyoruz
                }
                else if (mikrotaryBird[i] == maxMikrotaryCounter && ourArray[i] < mikrotaryCounterValue)
                {
                    /*
                    *Burası çok önemlidir çünki en dizinin ilgiili değişkeni en fazla tekrar etme miktarı ile aynı olabilir
                    * bu durumda en küçük değeri en fazla tekrar eden eleman diye alacağımız için bu şart bizim kilit noktamızdır
                     */
                    mikrotaryCounterValue = ourArray[i];
                }
            }


            Console.WriteLine(mikrotaryCounterValue);
        }





        public static int[] mikrotaryCounter(int[] ourArray)
        {
            int[] migrotaryBird = new int[ourArray.Length];
            for (int i = 0; i < ourArray.Length; i++)
            {
                for (int j = 0; j < ourArray.Length; j++)
                {
                    if (isFind(ourArray[i], ourArray, i))//İlgili metotta anlatılmıştır
                    {
                        continue;//İlgili metot sağlanıyorsa dizinin ilgili değişkeni es geçilir ve tekrar etme sayısı 0 atanır
                    }

                    if (ourArray[i] == ourArray[j])
                    {
                        /*
                         *dizideki ilgili indisdeki değer daha önce sayaca eklenmediysse ve yine tekrar edildiyse sayaç artar
                         */
                        migrotaryBird[i]++;

                    }
                }
            }
            return migrotaryBird;
        }







        public static bool isFind(int value, int [] array, int tempCounter)
        {
            /*
             *Bu kısımda kilit noktalar arasınd yer almaktaddır dizinin i.elemanı dizi ve i sayısı gönderilir
             *ve for döngüsü i sayısını almadan burası çok önemli ^^İ SAYISINI ALMADAN^^ o sayıya kadar olan
             * indisdeki değişkenleri dizinin i.elemanı ile kontrol eder ve eğer eşitlerse zaten o dizi sayaca
             * eklenmiştir demektir true değer döndererek ilgili indisin zaten daha önce sayaca dahil edildiğini
             * belirtir ve böylece sayaca dahil olmaz..
             */
            for (int i = 0; i < tempCounter; i++)
            {
                if (value == array[i])
                {
                    return true;
                }
            }

            return false;
        }


    }
}
