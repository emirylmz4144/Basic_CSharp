using System;
using System.Drawing;
using BarcodeLib;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace BarcodeGenerator
{
    public class BarcodeActions
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Barkod yazdırmak için metni girin: ");
            string text = Console.ReadLine();

            writeBarcode(text);
            readBarcode();
        }

        static void writeBarcode(string word)
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = true;

            //Barkodu resme dönüştürme
            Image img = barcode.Encode(TYPE.CODE128, word); 


            // Barkod resmini Bitmap'e dönüştürme
            Bitmap bmp = new Bitmap(img);

            string filePath = @"D:\Emirin yazılım şeysileri\CSharp--101\BarcodeGenerator\BarcodeGenerator\barcode.png";

            // Barkodu dosyaya kaydetme
            bmp.Save(filePath);
        }


        static void readBarcode()
        {
            Console.WriteLine("Barkod okuma işlemi başlatılıyor...");

            // Barkod okuyucu nesnesi oluşturma
            BarcodeReader barcodeReader = new BarcodeReader();
            var barcodeBitMap = new Bitmap(@"D:\Emirin yazılım şeysileri\CSharp--101\BarcodeGenerator\BarcodeGenerator\barcode.png");

            // Barkodu okuma
            var result = barcodeReader.Decode(barcodeBitMap);

            // Eğer barkod okunamazsa sonuç null olacaktır
            if (result != null)
            {
                Console.WriteLine("Barkod içeriği: " + result.Text);
            }
            else
            {
                Console.WriteLine("Barkod okunamadı.");
            }

            // Konsol penceresini açık tutmak için
            Console.ReadKey();
        }
    }
}

