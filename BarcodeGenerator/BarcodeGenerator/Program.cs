using System.Drawing;
using BarcodeLib;
using ZXing;


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
           

            Image img = barcode.Encode(TYPE.CODE128, word); //Barkodu resme dönüştürme

            Bitmap bmp = new Bitmap(img);// Barkod resmini Bitmap'e dönüştürme

            string filePath = @"D:\Emirin yazılım şeysileri\CSharp--101\BarcodeGenerator\BarcodeGenerator\barcode.png";

            bmp.Save(filePath);// Barkodu dosyaya kaydetme
        }
        

        static void readBarcode()
        {
            
            BarcodeReader barcodeReader = new BarcodeReader(); // Barkod okuyucu nesnesi oluşturma

            barcodeReader.Options.TryHarder = true; //Daha doğru okuma için

            var barcodeBitMap = new Bitmap(@"D:\Emirin yazılım şeysileri\CSharp--101\BarcodeGenerator\BarcodeGenerator\barcode.png");
            
            var result = barcodeReader.Decode(barcodeBitMap); // Barkodu okuma
            
            if (result != null) // Eğer barkod okunamazsa sonuç null olacaktır
                Console.WriteLine("Barkod içeriği: " + result.Text);
            else 
                Console.WriteLine("Barkod okunamadı.");
            

            // Konsol penceresini açık tutmak için
            Console.ReadKey();
        }
    }
}

