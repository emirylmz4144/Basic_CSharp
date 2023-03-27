using System;

namespace AtmApplications
{
    public class Log
    {
        public void succesFullLogin(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} - tarihinde başarılı giriş yaptı.";
            writeLog(id,logMessage);
        }

        public void failedLogin(string name, int id)
        {
            string logMessage =
                $"{id} kimlik numaralı {name} kişisi {DateTime.Now} - tarihinde başarısız giriş denemesi yaptı.";
            writeLog(id, logMessage);
        }

        public void succesfullWithdraw(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarılı para çekme işlemı gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        public void failedWithdraw(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarısız para çekme işlemi denemesi gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        public void succesfullDeposit(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarılı para yatırma işlemi denemesi gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        public void failedDeposit(string name, int id, int amount)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde {amount} miktarda başarısız para yatırma işlemi denemesi gerçekleştirmiştir";
            writeLog(id, logMessage);
        }

        public void succesfullSendMoney(string senderName, int senderId, int amount, string recipientName, int recipientId)
        {
            string logMessage = $"{senderId} kimlik numaralı {senderId} kişisi {DateTime.Now} tarihinde {recipientId} kimlik numaralı {recipientName} kişisine {amount} miktarda başarılı para gönderme işlemi gerçekleştirmiştir";
            writeLog(senderId, logMessage);
        }

        public void FailedSendMoney(string senderName, int senderId, int amount, string recipientName, int recipientId)
        {
            string logMessage = $"{senderId} kimlik numaralı {senderId} kişisi {DateTime.Now} tarihinde {recipientId} kimlik numaralı {recipientName} kişisine {amount} miktarda başarısız para gönderme işlemi denemesi gerçekleştirmiştir";
            writeLog(senderId, logMessage);
        }

        public void succesfullTakeMoney(string senderName, int senderId, int amount, string recipientName, int recipientId)
        {
            string logMessage = $"{senderId} kimlik numaralı {senderId} kişisi {DateTime.Now} tarihinde {recipientId} kimlik numaralı {recipientName} kişisinden {amount} miktarda başarılı para alma işlemi  gerçekleştirmiştir";
            writeLog(recipientId, logMessage);
        }

        public void viewBalance(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde bakiyesini görüntülemiştir";
            writeLog(id,logMessage);
        }

        public void LogOut(string name, int id)
        {
            string logMessage = $"{id} kimlik numaralı {name} kişisi {DateTime.Now} tarihinde hesabından çıkış yapmıştır";
            writeLog(id, logMessage);




        }

        public void checkAndCreate()
        {
            string filePath = @"D:\Emirin yazılım şeysileri\CSharp--101\AtmApplications\AtmApplications\userLogs";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);

                foreach (var person in DefaultAccount.persons)
                {
                    string logFilePath = Path.Combine(filePath, person.Id + ".txt");
                    if (!File.Exists(logFilePath))
                        File.Create(logFilePath);
                }
            }
            else
            {
                foreach (var person in DefaultAccount.persons)
                {
                    string logFilePath = Path.Combine(filePath, person.Id + ".txt");
                    if (!File.Exists(logFilePath))
                        File.Create(logFilePath);
                }
            }

        }

        public void writeLog(int id, string logMessage)
        {
            string folderPath = @"D:\Emirin yazılım şeysileri\CSharp--101\AtmApplications\AtmApplications\userLogs";
            string[] logFiles = Directory.GetFiles(folderPath, id + ".txt");

            if (logFiles.Length == 0)
            {
                Console.WriteLine($"Belirtilen id numaradında ( {id}  ) bir kişi bulunamadı");
                return;
            }


            string logFilePath = logFiles[0];

            using (StreamWriter logWriter=File.AppendText(logFilePath))
            {
                logWriter.WriteLine(logMessage);
            }
        }

        
    }
}

