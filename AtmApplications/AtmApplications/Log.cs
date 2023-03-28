using System;

namespace AtmApplications
{
    public class Log
    {
        //Başarılı giriş loglaması
        public void succesFullLogin(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} - tarihinde başarılı giriş yaptı.";
            writeLog(id,logMessage);
        }
        //Başarısız giriş loglaması
        public void failedLogin(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} - tarihinde başarısız giriş denemesi yaptı.";
            writeLog(id, logMessage);
        }
        //Başarılı para çekme loglaması
        public void succesfullWithdraw(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarılı para çekme işlemı gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        //Başarısız para çekme loglaması
        public void failedWithdraw(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarısız para çekme işlemi denemesi gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        //Başarılı para yatırma loglaması
        public void succesfullDeposit(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarılı para yatırma işlemi denemesi gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        //Başarısız para yatırma loglaması
        public void failedDeposit(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarısız para yatırma işlemi denemesi gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        //Başarılı para gönderme loglaması
        public void succesfullSendMoney(string senderName, int senderId, int amount, string recipientName, int recipientId)
        {
            string logMessage = $"{senderId} kimlik numaralı {senderName} kişisi {DateTime.Now} tarihinde {recipientId} kimlik numaralı {recipientName} kişisine {amount} miktarda başarılı para gönderme işlemi gerçekleştirmiştir";
            writeLog(senderId, logMessage);
        }

        //Başarısız para göndermek loglaması
        public void FailedSendMoney(string senderName, int senderId, int amount, string recipientName, int recipientId)
        {
            string logMessage = $"{senderId} kimlik numaralı {senderName} kişisi {DateTime.Now} tarihinde {recipientId} kimlik numaralı {recipientName} kişisine {amount} miktarda başarısız para gönderme işlemi denemesi gerçekleştirmiştir";
            writeLog(senderId, logMessage);
        }

        //Başarılı para almma loglaması
        public void succesfullTakeMoney(string senderName, int senderId, int amount, string recipientName, int recipientId)
        {
            string logMessage = $"{recipientId} kimlik numaralı {recipientName} kişisi {DateTime.Now} tarihinde {senderId} kimlik numaralı {senderName} kişisinden {amount} miktarda başarılı para alma işlemi  gerçekleştirmiştir";
            writeLog(recipientId, logMessage);
        }

        //Başarılı bakiye görüntüleme loglaması
        public void viewBalance(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde bakiyesini görüntülemiştir";
            writeLog(id,logMessage);
        }

        //Çıkış yapma loglaması
        public void LogOut(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde hesabından çıkış yapmıştır";
            writeLog(id, logMessage);
        }



        public void checkAndCreate()
        {
            /* Bu metot var olan listedeki her eleman için bir log dosyası oluşturma amacıyla yazılmıştır
             * Amaç belirtilen dosya yoluna gidip o dosya yolunda belirtilen klasörü açmak yoksa ise
             * o klasörü oluşturup listedeki her kullanıcı için bir file.txt açmak
             */
            string filePath = @"D:\Emirin yazılım şeysileri\CSharp--101\AtmApplications\AtmApplications\userLogs";
            if (!Directory.Exists(filePath))//Logların bulunduğu dosya yoksa oluşturur
            {
                Directory.CreateDirectory(filePath);//Dosya yoksa oluşturur

                foreach (var person in DefaultAccount.persons)//Her kullanıcıya bir file.txt açılır
                {
                    //Aşağıdaki kod ise string ifadeleri birleştirerek bir dosya yolu oluşturur
                    string logFilePath = Path.Combine(filePath, person.Id + ".txt");

                    if (!File.Exists(logFilePath))
                        File.Create(logFilePath);
                }
            }
            else
            {
                /*Logların bulunduğu dosya varsa listedeki elemanların her birine ait log.txt varmı diye
                 kontrol eder yoksa açar*/
                foreach (var person in DefaultAccount.persons)
                {
                    //Her kullanıcının id numarası ile bir log.txt açar
                    string logFilePath = Path.Combine(filePath, person.Id + ".txt");
                    if (!File.Exists(logFilePath))
                        File.Create(logFilePath);
                }
            }

        }

        //Log mesajını kullanıcının log dosyasına yazdıran metot
        public void writeLog(int id, string logMessage)
        {
            //Önce log dosyalarının bulunduğu ana dosyaya gideceğiz
            string folderPath = @"D:\Emirin yazılım şeysileri\CSharp--101\AtmApplications\AtmApplications\userLogs";
            //Sonra belirtilen dosya yolunu kapsayan log.txt dosya yollarını bir diziye aktaracağız
            string[] logFiles = Directory.GetFiles(folderPath, id + ".txt");

            if (logFiles.Length == 0)//Eğer dizi boyutu sıfırsa demekki öyle log.txt dosyaları yok
            {
                Console.WriteLine($"Belirtilen id numaradında ( {id}  ) bir kişi bulunamadı");
                return;
            }


            string logFilePath = logFiles[0];//Belirtilen koşulu sağlayan ilk log dosyasını alıyoruz

            //StreamWriter ile dosyaya yazdırma işlemi gerçekleştiriyoruz  
            using (StreamWriter logWriter=File.AppendText(logFilePath))
            {
                //AppenText() metodu var olan metin  dosyasına yeni bir metin dosyası eklemek için kullanılıır
                logWriter.WriteLine(logMessage);
            }
        }

        
    }
}

