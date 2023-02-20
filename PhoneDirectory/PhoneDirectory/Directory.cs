using System;

namespace PhoneDirectory
{
    public class Directory
    {
        public static void Main(string[] args)
        {


            DirectoryActionsMethods allActions = new DirectoryActionsMethods();
         
        Boolean status = true;
            while (status)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Telefon Rehberine Hoşgelidiniz\n\n\n" +
                    "1-Telefon numarası kaydet\n" +
                    "2-Telefon numarası sil\n" +
                    "3-Telefon numarası güncelle\n" +
                    "4-A-Z Sıralı şekilde kayıtlı numaraları göster\n" +
                    "5-Z-A Sıralı şekilde kayıtlı numaraları göster\n" +
                    "6-Rehberde arama\n" +
                    "0-Çıkış");
                

                int choose = int.Parse(Console.ReadLine());
                switch(choose)
                {
                    case 1:
                        allActions.add();
                        Console.WriteLine("----------------------------------------");
                        break;
                    case 2:
                        allActions.delete();
                        Console.WriteLine("----------------------------------------");
                        break;
                    case 3:
                        allActions.update();
                        Console.WriteLine("----------------------------------------");
                        break;
                    case 4:
                        allActions.listBySequentially();
                        Console.WriteLine("----------------------------------------");
                        break;
                    case 5:
                        allActions.listByPenultimate();
                        Console.WriteLine("----------------------------------------");
                        break;
                    case 6:
                        allActions.search();
                        break;
                    case 0:
                        status = false;
                        break;


                }
            }
        }
    }
}