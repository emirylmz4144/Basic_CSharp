using System;

namespace AtmApplications
{
    public class AtmActions
    {
       static Log log=new Log();
       static Person loggingPerson;
        public void run()
        {
            bool status = true;
            log.checkAndCreate();

            while (status)
            {

                userInformations:
                Console.WriteLine("Atm Uygulamasına hoş geldiniz Lütfen gerekli bilgileri giriniz: ");
                Console.Write("Id Kimlik numaranız: "); int Id=int.Parse(Console.ReadLine());
                Console.Write("Şifreniz: "); string password= Console.ReadLine();
                loggingPerson = findLogginPerson(Id, password);

                if (loggingPerson != null)
                {
                    bool status2 = true;
                    while (status2)
                    {
                        Console.WriteLine("---------Hoşgeldiniz "+loggingPerson.Name+" "+loggingPerson.Surnme+" Lütfen yapacağınız işlemi seçiniz:");
                        Console.WriteLine("1-Para Çekme\n" + "2-Para Yatırma\n" + "3-Para gönderme|n" + "4-Bakiye görüntüle\n" + "0-Çıkış yap" + "");
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


        public Person findLogginPerson(int Id,string password)
        {
            if (DefaultAccount.persons.FirstOrDefault(ı => ı.Id == Id) != null && DefaultAccount.persons.FirstOrDefault(p => p.Password == password) != null)
            {
                loggingPerson = DefaultAccount.persons.Find(p => p.Id == Id);
                log.succesFullLogin(loggingPerson.Name, loggingPerson.Id);
                return loggingPerson;
            }

            else if (DefaultAccount.persons.FirstOrDefault(ı => ı.Id == Id) != null)
            {
                loggingPerson = DefaultAccount.persons.Find(p => p.Id == Id);
                log.failedLogin(loggingPerson.Name, loggingPerson.Id);
                return null;
            }
            else if (DefaultAccount.persons.FirstOrDefault(p => p.Password == password) != null)
            {
                loggingPerson = DefaultAccount.persons.Find(p => p.Password == password);
                log.failedLogin(loggingPerson.Name, loggingPerson.Id);
                return null;
            }
            else
            {
                Console.WriteLine("Sistemde böyle bir kullanıcı yoktur..");
                return null;
            }
        }

        public void withDraw()
        {
            Console.WriteLine("Lütfen çekmek istediğiniz bakiye miktarını giriniz: ");int amount=int.Parse(Console.ReadLine());
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

        public void deposit()
        {
            Console.WriteLine("Lütfen yatırmak istediğiniz bakiye miktarını giriniz: "); int amount = int.Parse(Console.ReadLine());
            
                loggingPerson.Balance = loggingPerson.Balance + amount;
                Console.WriteLine("Para yatırma işlemi başarılı güncel tutar: " + loggingPerson.Balance);
                log.succesfullDeposit(loggingPerson.Name, loggingPerson.Id, amount);
            
        }

        public void sendMoney()
        {
            Console.WriteLine("Lütfen para yatırmak istediğiniz kişinin adını giriniz "); string name = Console.ReadLine();
            Console.WriteLine("Lütfen para göndermek istediğiniz kişinin Id numarasını giriniz: "); int Id=int.Parse(Console.ReadLine());
            Person recipientPerson = DefaultAccount.persons.Find(p => p.Id==Id);
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

        public void viewBalance()
        {
            Console.WriteLine("Güncel bakiyeniz: "+loggingPerson.Balance);
            log.viewBalance(loggingPerson.Name,loggingPerson.Id);
        }

    }
}
