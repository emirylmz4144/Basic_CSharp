using System;

namespace refUse
{
    class useToRef
    {
        static void Main(string[]args)
        {

            int x = 6;
            int y = 7;

            deneme(x, y);
            Console.WriteLine("x: " + x + "y: " + y); // x: 6 y:7
            deneme2(ref x, ref y);
            Console.WriteLine("x: " + x + "y: " + y); // x:10 y :11
        }
        static void deneme(int x, int y)
        {
            x = x + 4; y = y + 4;
        }
        static void deneme2(ref int x, ref int y)
        {
            x = x + 4; y = y + 4;
        }
    }
}
