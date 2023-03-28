using System;

namespace AtmApplications
{
    public class AtmActions
    {
       static Log log=new Log();
       static Person loggingPerson;
        public void run()
        {
            bool status = true;//Atm uygulamasını sonlandıran veya devam ettiren kontrol şartı
            while (status)
            {

             log.checkAndCreate();//Kullanıcı eklenebilme  ihtimali olduğu için atm her ana ekrana geldiğinde bu metot ile varsa eklenen kullanıcıya ait log dosyası oluştuturulur

                userInformations:
                Console.WriteLine("Atm Uygulamasına hoş geldiniz Lütfen gerekli bilgileri giriniz: ");
                Console.Write("Id Kimlik numaranız: "); int Id=int.Parse(Console.ReadLine());
                Console.Write("Şifreniz: "); string password= Console.ReadLine();

                loggingPerson = findLogginPerson(Id, password);

                if (loggingPerson != null)
                {
                    bool status2 = true;//Kullanıcı işlemlerini sonlandıran veya devam ettiren kontrol şartı
                    while (status2)
                    {
                        Console.WriteLine("---------Hoşgeldiniz "+loggingPerson.Name+" "+loggingPerson.Surnme+"---------------\n Lütfen yapacağınız işlemi seçiniz:");
                        Console.WriteLine("1-Para Çekme\n" + "2-Para Yatırma\n" + "3-Para gönderme\n" + "4-Bakiye görüntüle\n" + "0-Çıkış yap" + "");
                        int choose=int.Parse(Console.ReadLine());

                        switch (choose)
                        {
                            case 1:
                                withDraw();
                                break;
                            case 2:
                                deposit();
                                break;
                            case 3:
                                sendMoney();
                                break;
                            case 4:
                                viewBalance();
                                break;
                            case 0:
                                log.LogOut(loggingPerson.Name,loggingPerson.Id);
                                status2 = false;
                                break;

                        }
                    }
                }
                else
                    goto userInformations;
                
            }
        }

        //Kullanıcı giriş ve duruma göre loglama işlemi
        public Person findLogginPerson(int Id, string password)
        {
            /*
             * Bu metot gönderilen değerlerdeki kullanıcını varlığını kullanıcılar listesinde kontrol eder ve eğer gönderilen değerlerde
             * kullanıcı varsa o kullanıcıyı yoksa ise null değeri döndürür.
             */

            var loggingPerson = DefaultAccount.persons.FirstOrDefault(p => p.Id == Id && p.Password == password);//Gönderilen değerlerde kullanıcıyı kontrol eden metot

            if (loggingPerson != null)
            {
                log.succesFullLogin(loggingPerson.Name, loggingPerson.Id);
                return loggingPerson;
            }
            else
            {
                var userExists = DefaultAccount.persons.Any(p => p.Id == Id);//Eğer id numarası doğruysa demekki kullanıcı var ama giriş hatalı
                if (userExists)
                {
                    Console.WriteLine("Hatalı giriş..");
                    loggingPerson = DefaultAccount.persons.FirstOrDefault(p => p.Id == Id);
                    log.failedLogin(loggingPerson.Name, loggingPerson.Id);
                }
                else
                {
                    Console.WriteLine("Sistemde böyle bir kullanıcı yoktur..");
                }

                return null;
            }
        }

        //Para çekme ve duruma göre loglama işlemi
        public void withDraw()
        {
            Console.Write("Lütfen çekmek istediğiniz bakiye miktarını giriniz: ");int amount=int.Parse(Console.ReadLine());
            if (loggingPerson.Balance>amount)
            {
                loggingPerson.Balance = loggingPerson.Balance - amount;
                Console.WriteLine("Para çekme işlemi başarılı güncel tutar: "+loggingPerson.Balance);
                log.succesfullWithdraw(loggingPerson.Name,loggingPerson.Id,amount);
            }
            else
            {
                Console.WriteLine("Bakiye Yetersiz ...");
                log.failedWithdraw(loggingPerson.Name,loggingPerson.Id,amount);
            }
        }

        //Para yatıtma ve loglama işlemi
        public void deposit()
        {
            Console.Write("Lütfen yatırmak istediğiniz bakiye miktarını giriniz: "); int amount = int.Parse(Console.ReadLine());
            
                loggingPerson.Balance = loggingPerson.Balance + amount;
                Console.WriteLine("Para yatırma işlemi başarılı güncel tutar: " + loggingPerson.Balance);
                log.succesfullDeposit(loggingPerson.Name, loggingPerson.Id, amount);
            
        }

        //Para gönderme ve duruma göre loglama işlemi
        public void sendMoney()
        {
            Console.Write("Lütfen para yatırmak istediğiniz kişinin adını giriniz "); string name = Console.ReadLine();
            Console.Write("Lütfen para göndermek istediğiniz kişinin Id numarasını giriniz: "); int Id=int.Parse(Console.ReadLine());
            Person recipientPerson = DefaultAccount.persons.Find(p => p.Id==Id && p.Name==name);
            if (recipientPerson!=null)
            {
                Console.WriteLine("Lütfen göndermek istediğiniz tutarı giriniz: ");int amount= int.Parse(Console.ReadLine());
                if (loggingPerson.Balance>amount)
                {
                    loggingPerson.Balance = loggingPerson.Balance - amount;
                    recipientPerson.Balance = recipientPerson.Balance + amount;
                    Console.WriteLine("Para gönderme işlemi başarı ile gerçekleşti");
                    log.succesfullSendMoney(loggingPerson.Name,loggingPerson.Id,amount,recipientPerson.Name,recipientPerson.Id);
                    log.succesfullTakeMoney(loggingPerson.Name,loggingPerson.Id,amount,recipientPerson.Name,recipientPerson.Id);
                    
                }
                else
                {
                    Console.WriteLine("Bakiye yetersiz...");
                    log.FailedSendMoney(loggingPerson.Name,loggingPerson.Id,amount,recipientPerson.Name,recipientPerson.Id);
                }
            }

        }

        //Bakiye görüntüleme işlemi
        public void viewBalance()
        {
            Console.WriteLine("Güncel bakiyeniz: "+loggingPerson.Balance);
            log.viewBalance(loggingPerson.Name,loggingPerson.Id);
        }


        //  Buralara isteğe göre kullanıcı ekleme kullanıcı silme şifre değiştirme vb... işlemler eklenebilir
         

    }
}
