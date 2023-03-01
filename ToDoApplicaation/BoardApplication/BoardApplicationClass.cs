using System;

namespace ToDoApplication
{
   public class BoardApplicationClass
    {
         static Dictionary<int, Person> people = OurDefaultAccount.ourDefaultPerson();
          

        public void run()
        {
            
            CartMenager toDoCart = new ToDoCart("İngilizce","İngilizce dersine çalışmalısın", people[1]);
            CartMenager inProgressCart = new InProgress("Web development", "Web deveelepment alanında gelişmelisin", people[1]);
            CartMenager DoneCart = new Done("Java", "Java alanında da gelişmelisin", people[1]);

            bool status = true;
            while(status)
            {
                Console.WriteLine("Lütfen yapacağınız işlemi seçiniz: \n" + "1-Kart Ekleme\n" + "2-Kart Çıkarma\n" + "3-Kart Güncelle\n" + "4-Kart taşı\n" + "5-Board listeleme\n"+"6-Kişileri Görüntüle\n"+"0-Çıkış");
                int choose = int.Parse(Console.ReadLine());
                switch(choose)
                {
                    case 1:
                        addCart();
                        break;
                    case 2:
                        deleteCart();
                        break;
                    case 3:
                        updateCart();
                        break;
                    case 4:
                        reLocationToCart();
                        break;
                    case 5:
                        listToBoard();
                        break;
                    case 6:
                        showAllPerson();
                        break;
                    case 0:
                        status = false;
                        break;
                       
                }
            }
        }



        public void addCart()
        {
            Console.Write("Lütfen kart başlığını giriniz: "); string title=Console.ReadLine();
            Console.Write("Lütfen kart içeriğinini giriniz: "); string contents=Console.ReadLine();
            showAllPerson();
            Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); int id=int.Parse(Console.ReadLine());

            // Girilen ıd'nin kesin bir şekilde doğru girilmesi
            while (!people.Keys.Contains(id))
            {
                Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  ");  id = int.Parse(Console.ReadLine());
            }
            Person selectedPerson = people[id];
            Console.WriteLine("Lütfen ekleyeceğiniz kartın hangi kolona ekleneceğini giriniz \n(1)-ToDo-(L)\n(2)-InProgress-(M)\n(3)-Done-(S)");
            int choose = int.Parse(Console.ReadLine());



            // Kartın hangi kolona girilmesi gerektiği
            if(choose==1)
            {
                Console.WriteLine("ToDo Listesine Kart Eklendi..");
                CartMenager newToDoCart = new ToDoCart(title, contents, selectedPerson);
            }
            else if (choose == 2)
            {
                Console.WriteLine("InProgress Listesine Kart Eklendi..");
                CartMenager newInProgressCart = new InProgress(title, contents, selectedPerson);
            }
            else if(choose == 3)
            {
                Console.WriteLine("Done Listesine Kart Eklendi..");
                CartMenager newDoneCart = new Done(title, contents, selectedPerson);
            }
          
        }






        





        public void deleteCart()
        {
            Console.WriteLine("Hangi bölümdeki kartı sileceksiniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done");
            int choose = int.Parse(Console.ReadLine());
            Console.WriteLine("Konu başlığını giriniz: "); string title = Console.ReadLine();//Başlık kullanıcıdan alınır

            // Seçilen ToDo  İSE
            if (choose == 1)
            {
                for (int i = 0; i < ToDoCart.Carts.Count; i++)
                {
                    if (ToDoCart.Carts[i].Title == title)
                    {
                        ToDoCart.Carts.Remove(ToDoCart.Carts[i]);
                    }
                    else if (i == ToDoCart.Carts.Count - 1)// Son elemana geldiği halde bulunmamışsa demek öyle bir kart yoktur
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }
            //Seçilen InProgress ise
            else if (choose == 2)
            {             
                for (int i = 0; i < InProgress.Carts.Count; i++)
                {
                    if (InProgress.Carts[i].Title == title)
                    {
                        InProgress.Carts.Remove(InProgress.Carts[i]);
                    }
                    else if (i == InProgress.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }
            // Seçilen Done ise
            else if (choose == 3)
            {
                for (int i = 0; i < Done.Carts.Count; i++)
                {
                    if (Done.Carts[i].Title == title)
                    {
                        Done.Carts.Remove(Done.Carts[i]);
                    }
                    else if (i == Done.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;

                    }

                }

            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir işlem giriniz..");
            }
        }














        public void updateCart()
        {
            //Bu kısımda yeni veriler alınır
            Console.Write("Lütfen kart başlığını giriniz: "); String newTitle = Console.ReadLine();
            Console.Write("Lütfen kart içeriğinini giriniz: "); String newContents = Console.ReadLine();
            showAllPerson();
            Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); int id = int.Parse(Console.ReadLine());
            while (!people.Keys.Contains(id))
            {
                Console.WriteLine("Lütfen yukarıdaki id numaralarına sahip kişilerden birini atayınız:  "); id = int.Parse(Console.ReadLine());
            }
            Person newSelectedPerson = people[id];
            Console.WriteLine("Lütfen güncellemek istediğiniz Kartın hanngi bölümde olduğunu giriniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done");
            int choose=int.Parse(Console.ReadLine());



            if(choose==1)
            {
                Console.WriteLine("Eski başlığı giriniz: "); string oldTitle = Console.ReadLine();
                for (int i = 0; i < ToDoCart.Carts.Count; i++)
                {
                    if (ToDoCart.Carts[i].Title == oldTitle)
                    {
                        ToDoCart.Carts[i].Title=newTitle;
                        ToDoCart.Carts[i].Contents = newContents;
                        ToDoCart.Carts[i].AppointedPerson = newSelectedPerson;
                        break;
                    }
                    else if (i == ToDoCart.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }

            }



            else if(choose==2)
            {
                Console.WriteLine("Eski başlığı giriniz: "); string oldTitle = Console.ReadLine();
                for (int i = 0; i < InProgress.Carts.Count; i++)
                {
                    if (InProgress.Carts[i].Title == oldTitle)
                    {
                        InProgress.Carts[i].Title = newTitle;
                        InProgress.Carts[i].Contents = newContents;
                        InProgress.Carts[i].AppointedPerson = newSelectedPerson;
                        break;
                    }
                    else if (i == InProgress.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }

           else if(choose==3)
            {
                Console.WriteLine("Eski başlığı giriniz: "); string oldTitle = Console.ReadLine();
                for (int i = 0; i < Done.Carts.Count; i++)
                {
                    if (Done.Carts[i].Title == oldTitle)
                    {
                        Done.Carts[i].Title = newTitle;
                        Done.Carts[i].Contents = newContents;
                        Done.Carts[i].AppointedPerson = newSelectedPerson;
                        break;
                    }
                    else if (i == Done.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }

            else
            {
                Console.WriteLine("Lütfen geçerli bir seçim yapınız..");
            }

        }












        public void reLocationToCart()
        {
            Console.WriteLine("Lütfen hangi kolondaki kartı seçmek istediğinizi belirtiniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done"); int choose=int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen kartı hangi kolona taşımak istediğinizi belirtiniz\n(1)-ToDo\n(2)-InProgress\n(3)-Done"); int newLocationChoose=int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen kart başlığını giriniz: "); string title = Console.ReadLine();


            //------Buradakilerin aynısı
            //1.Kolondaki veri saklanacaksa
            if (choose==1)
            {

                
                for (int i = 0; i < ToDoCart.Carts.Count; i++)
                {
                    if (ToDoCart.Carts[i].Title == title)
                    {
                        if (newLocationChoose == 1)//Aynı kolona ekleniyorsa otomotik olarak döngüden çıkar
                            break;
                        else if (newLocationChoose == 2)// 2.kolona eklenecekse;
                        {
                            //Alınan kolonaki kart bilgileri yeni kart olarak eklenecek olan kolona eklenir..
                            InProgress newCart=new InProgress(ToDoCart.Carts[i].Title, ToDoCart.Carts[i].Contents, ToDoCart.Carts[i].AppointedPerson);
                            //Ve mevcut var olduğu kolondan silinir
                            ToDoCart.Carts.Remove(ToDoCart.Carts[i]);
                            break;
                        }
                        else if(newLocationChoose==3)
                        {
                            Done newCart=new Done(ToDoCart.Carts[i].Title, ToDoCart.Carts[i].Contents, ToDoCart.Carts[i].AppointedPerson);
                            ToDoCart.Carts.Remove(ToDoCart.Carts[i]);
                            break;
                        }
                   
                    }
                    else if (i == ToDoCart.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }




            //------Buradakilerin aynısı
            else if (choose == 2)
            {
                for (int i = 0; i < InProgress.Carts.Count; i++)
                {
                    if (InProgress.Carts[i].Title == title)
                    {
                        if (newLocationChoose == 1)
                        {
                            ToDoCart newCart=new ToDoCart(InProgress.Carts[i].Title, InProgress .Carts[i].Contents, InProgress.Carts[i].AppointedPerson);
                            InProgress.Carts.Remove(InProgress.Carts[i]);
                            break;
                        }
                        
                        else if (newLocationChoose == 2) 
                            break;
                        else if (newLocationChoose == 3)
                        {
                            Done newCart=new Done(InProgress.Carts[i].Title, InProgress.Carts[i].Contents, InProgress.Carts[i].AppointedPerson);
                            InProgress.Carts.Remove(InProgress.Carts[i]);
                            break;
                        }

                    }
                    else if (i == InProgress.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }





            //------Buradakilerin aynısı
            if (choose == 3)
            {
                for (int i = 0; i <Done.Carts.Count; i++)
                {
                    if (Done.Carts[i].Title == title)
                    {
                        if (newLocationChoose == 1)
                        {
                            ToDoCart newCart=new ToDoCart( Done.Carts[i].Title, Done.Carts[i].Contents, Done.Carts[i].AppointedPerson);
                            Done.Carts.Remove(Done.Carts[i]);
                            break;
                        }
                        else if (newLocationChoose == 2)
                        {
                            InProgress newCart=new InProgress(Done.Carts[i].Title, Done.Carts[i].Contents, Done.Carts[i].AppointedPerson);
                            Done.Carts.Remove(Done.Carts[i]);
                            break;
                        }
                        else if (newLocationChoose == 3) 
                            break;
                        

                    }
                    else if (i == ToDoCart.Carts.Count - 1)
                    {
                        Console.WriteLine("ARANILAN BAŞLIKTA BİR KART BULUNAMAMIŞTIR");
                        break;
                    }
                }
            }
            Console.WriteLine("Kart taşıma işlemi tamamlandı..");
        }












        public void listToBoard()
        {
            Console.WriteLine("**********************ToDo Listesi**********************");
            ToDoCart.listToCarts();
            Console.WriteLine("**********************InProgress Listesi*****************");
            InProgress.listToCarts();
            Console.WriteLine("**********************Done Listesi***********************");
            Done.listToCarts();

        }












        public void showAllPerson()
        {
            Console.WriteLine("------Kişiler------");
            foreach(Person person in people.Values)
            {
                Console.WriteLine("Ad: " + person.Name);
                Console.WriteLine("Soyad:  " + person.SurName);
                Console.WriteLine("ID:  " +person.ID);
                Console.WriteLine("-------------------");
            }
        }

    } 
}
