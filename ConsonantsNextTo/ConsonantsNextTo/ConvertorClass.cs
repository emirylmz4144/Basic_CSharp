using System;
using System.ComponentModel;


namespace ConsonantsNextTo
{
    public static class ConvertorClass
    {
        public static bool[] returnTheStatus(string[] arrayText)
        {
            bool[] allWordsStatus = new bool[arrayText.Length];
            char[] ourConstChars = { 'a', 'e', 'ı', 'i', 'o', 'ö', 'u', 'ü' };//Bu harflerin dışında olanlar sessiz harflerdir

            for (int i = 0; i < arrayText.Length; i++)
            {
                string word = arrayText[i];
                for (int j = 0; j < word.Length-1; j++)
                {
                    if (!ourConstChars.Contains(word[j]) && !ourConstChars.Contains(word[j+1]))//Eğer harflerin dışındakileri 2 eleman içeriyorsa o zaman sessiler yanyanadır
                    {
                        {
                            allWordsStatus[i] = true;
                            break;
                        }
                    }
                    
                    
                }
            }

            return allWordsStatus;
        }
    }
}
