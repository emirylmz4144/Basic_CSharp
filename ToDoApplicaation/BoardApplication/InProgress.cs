using System;

namespace ToDoApplication
{
    public class InProgress:CartMenager
    {
        public static List<InProgress> Carts = new List<InProgress>();

        public InProgress( string title, string contents, Person appointedPerson)
            : base("InProgress LİSTESİ ", title, contents, appointedPerson,Size.M)
        {
            Carts.Add(this);
        }

        public static void listToCarts()
        {
            for (int i = 0; i < Carts.Count; i++)
            {
                Console.WriteLine("Kart adı: " + Carts[i].Title);
                Console.WriteLine("Kart içeriği: " + Carts[i].Contents);
                Console.WriteLine("Atanan Kişi:  " + Carts[i].AppointedPerson.Name + " " + Carts[i].AppointedPerson.SurName);
                Console.WriteLine("Kart Büyüklüğü: " + Carts[i].Size);
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}
