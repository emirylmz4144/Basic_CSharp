using System;
using System.Collections;
using System.ComponentModel;

namespace PhoneDirectory
{
    public class DirectoryActionsMethods
    {
        List<Person> Persons = new List<Person>();// Listemiz bir sınıfı tutacak böylece kişiye ait sınıfımız daha kolay tutulacaktır.
        public DirectoryActionsMethods()
        {
            // Başlagıç olarak 5 adet numara constuructorda atanmıştır
            Persons.Add(new Person("emir", "yılmaz", "05366729863"));
            Persons.Add(new Person("hilal", "yılmaz", "05366729863"));
            Persons.Add( new Person("bilal", "yılmaz", "05366729863"));
            Persons.Add(new Person("mevbure", "yılmaz", "05366729863"));
            Persons.Add(new Person("cesim efe", "yılmaz", "05366729863"));
        }

        public void add()
        {

            Console.Write("Lütfen kişi adını giriniz: "); String name = Console.ReadLine(); name = name.ToLower();// Karışıklık olmasın diye sistemde tüm harfler küçük tutulur
            Console.Write("Lütfen kişi soyadını giriniz: "); String surName = Console.ReadLine(); surName = surName.ToLower();
            Console.Write("Lütfen kişi numarasını giriniz: "); String number = Console.ReadLine(); 

            Person newPerson = new Person(name, surName, number);
            Persons.Add(newPerson);
            Console.WriteLine(name+" Adlı kişi rehbere kaydedilmiştir..");

        }

        public void delete()
        {
            head:
            Console.WriteLine("Lütfen kişinin ismini veya soyismini giriniz: "); String nameOrSurnameForDelete = Console.ReadLine();
            nameOrSurnameForDelete = nameOrSurnameForDelete.ToLower();// Karışıklık çıkmasın diye tüm harfler küçültülür

          
            for(int i=0;i<Persons.Count;i++)
            {
                
                
                if (Persons[i].Name.Equals(nameOrSurnameForDelete) || Persons[i].SurName.Equals(nameOrSurnameForDelete))// İsim veya soyisim uyuşuyorsa şartın sağlanması gerçekleştirilir
                {
                    Console.WriteLine(Persons[i].Name + " Adlı kişi silinecektir onaylıyorsanız (1) onaylamıyorsanız (0) tuşlayınız");
                    int chooseToValue = int.Parse(Console.ReadLine());
                    if (chooseToValue == 1)
                    {
                        Console.WriteLine(Persons[i].Name + " Adlı kişi rehberden silinmiştir..");
                        Persons.RemoveAt(i);
                        break;
                    }
                    else
                        break;
                   
                }
                if (i == Persons.Count - 1)// Eğer listenin son elemanı bile uyuşmuyorsa demekki böyle bir eleman yoktur
                {
                    Console.WriteLine("Aranan kişi rehberde kayıtlı değildir..tekrar denemek için (1) silme işlemimnden çıkmak için (0) basınız");
                    int chooseToValue = int.Parse(Console.ReadLine());
                    if (chooseToValue == 1)
                        goto head;
                    else
                        break;
                }

            }
            
        }

        public void update()
        {
        head:
            Console.WriteLine("Lütfen kişinin ismini veya soyismini giriniz: "); String nameOrSurnameForDelete = Console.ReadLine();
            nameOrSurnameForDelete = nameOrSurnameForDelete.ToLower();


            for (int i = 0; i < Persons.Count; i++)
            {
                

                if (Persons[i].Name.Equals(nameOrSurnameForDelete) || Persons[i].SurName.Equals(nameOrSurnameForDelete))
                {
                    Console.WriteLine("(1) ADI GÜNCELLE\n(2) SOYADI GÜNCELLE\n (3) NUMARAYI GÜNCELLE\n(0)GÜNCELLEMEKTEN VAZGEÇ");
                    int chooseToValue = int.Parse(Console.ReadLine());
                    if(chooseToValue==1)
                    {
                        Console.WriteLine("Lütfen yeni adı giriniz: "); string newName = Console.ReadLine();
                        Console.Write(Persons[i].Name + " adlı kişinin ismi ");
                        Persons[i].Name = newName;
                        Console.WriteLine(Persons[i].Name + " olarak güncellenmiştir");
                        break;
                    }
                    else if(chooseToValue==2)
                     {
                        Console.WriteLine("Lütfen yeni soyadını  giriniz: "); string newSurname = Console.ReadLine();
                        Console.Write(Persons[i].SurName + " adlı kişinin ismi ");
                        Persons[i].Name = newSurname;
                        Console.WriteLine(Persons[i].SurName + " olarak güncellenmiştir");
                        break;
                    }
                    else if(chooseToValue==3)
                    {
                        Console.WriteLine("Lütfen yeni numarayı giriniz: "); string newNumber = Console.ReadLine();
                        Console.Write(Persons[i].Number + " adlı kişinin numarası ");
                        Persons[i].Number = newNumber;
                        Console.WriteLine(Persons[i].Number + " olarak güncellenmiştir");
                        break;
                    }
                    else
                    {
                        break;
                    }
                    

                }
                if (i == Persons.Count - 1)
                {
                    Console.WriteLine("Aranan kişi rehberde kayıtlı değildir..tekrar denemek için (1) güncelleme işlemimnden çıkmak için (0) basınız");
                    int chooseToValue = int.Parse(Console.ReadLine());
                    if (chooseToValue == 1)
                        goto head;
                    else
                        break;
                }

            }
        }

        public void listBySequentially()
        {
            var sortedPersons = Persons.OrderBy(value => value.Name);// Bir sınıfa ait özelliğe göre sıralama yapmak istenirse bu şekilde kullanım yapılır.
            foreach(var person in sortedPersons)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Kişi adı: " + person.Name);
                Console.WriteLine("Kişi soyadı: " + person.SurName);
                Console.WriteLine("Kişi numarası: " + person.Number);
                Console.WriteLine("----------------------------------------");
            }
        }

        public void listByPenultimate()
        {
            var sortedPersons = Persons.OrderBy(value => value.Name).Reverse();
            foreach(var person in sortedPersons)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Kişi adı: " + person.Name);
                Console.WriteLine("Kişi soyadı: " + person.SurName);
                Console.WriteLine("Kişi numarası: " + person.Number);
                Console.WriteLine("----------------------------------------");
            }

        }

        public void search()
        {
            Console.WriteLine("Lütfen aramak istediğiniz kişinin adını veya soyadını giriniz: "); string nameOrSurname = Console.ReadLine();
            nameOrSurname = nameOrSurname.ToLower();
            for(int i=0;i<Persons.Count;i++)
            {
                
                if (Persons[i].Name.Equals(nameOrSurname) || Persons[i].SurName.Equals(nameOrSurname))
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine("Kişinin adı: " + Persons[i].Name);
                    Console.WriteLine("Kişinin adı: " + Persons[i].SurName);
                    Console.WriteLine("Kişinin adı: " + Persons[i].Number);
                    Console.WriteLine("----------------------------------------");

                }
                if (i == Persons.Count - 1)
                {
                    Console.WriteLine("Aranan kişi telefon rehber listesinde bulunmamakta ");
                    break;
                }
            }

        }
    }
}
