using System;

namespace chaReverse
{
    public static class Reverse
    {
        public static string ReverseToString(string ourString)
        {
            string [] list = ourString.Split(" ");  
            string newString = "";
            

            for(int i=0;i<list.Length;i++)
            {
                
                char[] chars= list[i].ToCharArray();

                char tempChar= chars[0];//Değişim yapılacağı için ilk harf kaybolmasın diye geçici bir şekilde tutulur

                // Kelimelerin ilk ve son karakterleri yer değiştirir
                chars[0]= chars[chars.Length-1];
                chars[chars.Length - 1] = tempChar;

                string updatedWord = new string(chars);// dizi şeklinde olan kelimemiz string değere aktarılır
                newString += updatedWord+" ";

            }
            
            return newString;
        }
    }
}
