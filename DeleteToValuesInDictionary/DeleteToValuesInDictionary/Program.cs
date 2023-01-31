using System;

namespace ourProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Object, Object> ourDictionary = new Dictionary<Object, Object>();
            ourDictionary.Add(3, "C");
            ourDictionary.Add(4, "Sharp");
            ourDictionary.Add(5, "Example");
            ourDictionary.Add(6, "For");
            ourDictionary.Add(7, "Dictionary");
            ourDictionary.Add(8, "Collection");


            foreach (Object key in ourDictionary.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (Object value in ourDictionary.Keys)
            {
                int ourValue = Convert.ToInt32(value);
                if (ourValue % 2 == 0)
                {
                    Console.WriteLine(ourValue + " 2 ile tam bölündüğü için siliniyor..");
                    ourDictionary.Remove(value);
                }
            }
            foreach (Object values in ourDictionary.Values)
            {
                Console.WriteLine(values);
            }
        }
    }
}