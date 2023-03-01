using System;


namespace ToDoApplication
{

    public class ToDoCart : CartMenager
    {


        public static List<ToDoCart> Carts = new List<ToDoCart>();

        public ToDoCart(string title, string contents, Person appointedPerson) :
            base("To-Do LİSTESİ", title, contents, appointedPerson,Size.L)
        {
            Carts.Add(this);
        }

        public static  void listToCarts()
        {
            for(int i=0;i<Carts.Count;i++)
            {
                Console.WriteLine("Kart adı: " + Carts[i].Title);
                Console.WriteLine("Kart içeriği: " + Carts[i].Contents);
                Console.WriteLine("Atanan Kişi:  " + Carts[i].AppointedPerson.Name+" "+ Carts[i].AppointedPerson.SurName);
                Console.WriteLine("Kart Büyüklüğü: " + Carts[i].Size);
                Console.WriteLine("---------------------------------------------------");
            }
        }

    }
}
