using System;


namespace CircleDraw
{
    class Circle
    {

        static void Main(string[] args)
        {
            back:
                double radius;
            double thickness = 0.2;
            Console.WriteLine("Lütfen 0 tam büyük  bir tamsayı  yarıçap giriniz: ");

                if (!double.TryParse(Console.ReadLine(), out radius) || radius <= 0)
                    goto back;

            Console.WriteLine();
            double innerCircle = radius - thickness;
            double outerCircle = radius + thickness;

            /*çemberin iki tarafı olduğu için koordinat eksenine göre + ve - tarafları olacaktır bu  yüzden yarıçaptan başlayayıp 0 'a oradan da 
             -radiusa inerek çemberi tamamlar*/
            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x < outerCircle; x += 0.5)
                {
                    /*Çemberin çiziminde olan formül iç çember ve dış çembere göre belirlenir
                     * Eğer hesaplanan nokta, çemberin içindeyse, yani x^2 + y^2 <= radius^2 ise "*" karakteri yazdırılır
                     * değilse boşluk karakteri yazdırılır.  */
                    double value = x * x + y * y;
                    if (value >= innerCircle * innerCircle && value <= outerCircle * outerCircle)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.ReadKey();




        }
    }
}