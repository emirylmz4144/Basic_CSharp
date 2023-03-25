using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using Document = iTextSharp.text.Document;

namespace QRCodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // QR kodunun içeriği
            string qrcodeContent = "https://app.patika.dev/denizceylan";

            // QR kod boyutu
            int qrcodeSize = 300;

            // QR kod nesnesi oluşturma
            BarcodeQRCode qrcode = new BarcodeQRCode(qrcodeContent, qrcodeSize, qrcodeSize, null);

            // QR kod görüntüsünü elde etme
            iTextSharp.text.Image qrcodeImage = qrcode.GetImage();

            // QR kod dosya yolu
            string filePath = @"C:\Users\mypc\source\repos\ZorSeviyeUygulamalar\qrcode.pdf";

            // PDF dosyası oluşturma
            Document pdfDoc = new Document(PageSize.A4, 50, 50, 25, 25);

            // PDF dosyasını oluştur
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, new FileStream(filePath, FileMode.Create));

            // PDF dosyasını aç
            pdfDoc.Open();

            // QR kod görüntüsünü PDF dosyasına ekle
            pdfDoc.Add(qrcodeImage);

            // PDF dosyasını kapat
            pdfDoc.Close();

            // Okunan QR kodu göstermek için bekleyin
            Console.WriteLine("Lütfen QR kodu okutun ve enter tuşuna basın.");
            Console.ReadLine();

            // Okunan QR kodu tutacak değişkeni tanımlama
            string readQrcodeContent = "";

            // Okunan PDF dosyasını açma
            using (PdfReader reader = new PdfReader(filePath))
            {
                // Sayfa sayısını alın
                int pageCount = reader.NumberOfPages;

                // Sayfaları döngü ile oku
                for (int i = 1; i <= pageCount; i++)
                {
                    // Sayfadaki verileri alma
                    string pageContent = PdfTextExtractor.GetTextFromPage(reader, i);

                    // QR kod içeriği var mı kontrol etme
                    if (pageContent.Contains(qrcodeContent))
                    {
                        // Okunan QR kod içeriğini al
                        readQrcodeContent = qrcodeContent;
                        break;
                    }
                }
            }

            // Okunan QR kod içeriğini göster
            Console.WriteLine("Okunan QR kod içeriği: " + readQrcodeContent);

            // Konsolu açık tutmak için bekleyin
            Console.ReadLine();
        }
    }
}