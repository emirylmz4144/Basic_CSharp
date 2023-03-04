using System;

namespace BasicAlgorithm
{
   public class ourMain
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen istenilen formattaki metini yazınız: ");
            string ourString=Console.ReadLine();

            string [] ourStringArray = ourString.Split(",");
            for(int i=0;i<ourStringArray.Length;i++) 
            {
                //Mantıken 0 da kelime 1 de değer olacak o yüzden 2 ile bölümden kalan 0 değilse bir önceki kelimeden silinecek olan indexin sırasını verir
               if(i%2!=0) 
                {
                    //Substring metodu ile bu işlem yapılır 0 dan value'ya kadar value'dan kelimenin sonuna kadar olan harfleri birleştiririz
                    int value = int.Parse(ourStringArray[i]);
                    ourStringArray[i - 1] = ourStringArray[i - 1].Substring(0, value) + ourStringArray[i - 1].Substring(value+1);
                    
                }
            }

          
            foreach(string value in ourStringArray)
            {
                //Burada ise numeric değerleri değil direkt elde edilen düzenlenmiş dizideki düzenlenmiş elemanları görmek için numerik değerleri yazmadan stringleri yazıyoruz
                int isNumeric;
                if(!int.TryParse(value,out isNumeric))
                {
                    Console.WriteLine(value);
                   
                }
                
            }
        }
    }
}