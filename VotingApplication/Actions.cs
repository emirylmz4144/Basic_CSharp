using System;


namespace VotingApplication
{
    public class Actions
    {
        public void run()
        {
            
            bool status = true;
            while (status)
            {
                Console.Write("Lütfen yapacağınız işlemi seçiniz: \n" +
                                  "1-Kategorilere Puan ver\n" +
                                  "2-Kayıtlı kullanıcları görmek\n" +
                                  "3-Kategori puan listeleme\n");
                re:
                int choose=int.Parse(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        giveVoteToACategorie(); 
                        break;
                    case 2:
                        listToUsers();
                        break;
                    case 3:
                        showTheVotes();
                        break;
                    default:
                        Console.Write("Lütfen geçerli bir işlem giriniz: ");
                        goto re;


                }
            }
        }




        public void showTheVotes()
        {
            Console.WriteLine("Film kategorisi puanı: "+Film.votateOfType/Film.personQuality+"/10");
            Console.WriteLine("Filmin başarı oranı: " + (Film.votateOfType / Film.personQuality) * 10 + "/100");
        }




        public void giveVoteToACategorie()
        {
           
            Console.Write("Lütfen kullanıcı adınızı giriniz: ");
            string userName= Console.ReadLine();
            userName = userName.ToLower();


            Person ourUser = Person.GetUserByUsername(userName);
            if (ourUser == null)
            {
                Person.ourPersons.Add(new Person(userName));
                Console.WriteLine("Yeni kullanıcı kaydedildi");
                ourUser = Person.ourPersons[Person.ourPersons.Count - 1];
            }
                
           


            Console.WriteLine("Hosşgeldiniz" + ourUser.Name + " hangi Kategoriye Oy Vereceksiniz: \n" +
                              "1-Film Kategorisi\n" +
                              "2-Spor Kategorisi\n" +
                              "3-Müzik Kategorisi");
            int choose = int.Parse(Console.ReadLine());


            Console.WriteLine("Lütfen puanınızı giriniz: (1-10) ");
            double vote = double.Parse(Console.ReadLine());
            while (vote<1 || vote>10)
               vote= double.Parse(Console.ReadLine());


            ourUser.personsVote = vote;
            Console.WriteLine(ourUser.personsVote);

            re:
            switch (choose)
            {

                case 1:
                    Film.votateOfType += vote;
                    Film.personQuality++;
                    break;
                case 2:
                    Sport.votateOfType += vote;
                    Sport.personQuality++;
                    break;
                case 3:
                    Music.votateOfType += vote;
                    Music.personQuality++;
                    break;
                default:
                    Console.WriteLine("Lütfen geçerli bir işlem yapınız: ");
                    goto re;
                    break;

            }
        }

        public void listToUsers()
        {
            foreach (var user in Person.ourPersons)
            {
                Console.WriteLine("Kullanıcı adı: "+user.Name);
                Console.WriteLine("Kullanıcı puanı: "+user.personsVote);
                Console.WriteLine("---------------------------------");
            }
        }

        
    }
}
