using System;
using System.Configuration; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirpathIN = @ConfigurationManager.AppSettings.Get("dirpathIN");
            string dirpathOUT = @ConfigurationManager.AppSettings.Get("dirpathOUT");
            int linesQuantity = Convert.ToInt32(@ConfigurationManager.AppSettings.Get("LinesQuantity"));

            SplitFile(dirpathIN, dirpathOUT, linesQuantity);
            Console.WriteLine("Готово!");
            Console.ReadKey();
        }

        static void SplitFile(string inDir, string outDir, int linesQ)
        {
            var dirIN = new DirectoryInfo(@inDir); //папка с входящими файлами 
            var dirOUT = new DirectoryInfo(@outDir); //папка с исходящими файлами  
            string fileName = "";
            int count = 0;

            foreach (FileInfo file in dirIN.GetFiles())
            {
                string[] curentFile;
                fileName = Path.GetFileName(file.FullName);
                Console.WriteLine(fileName);
                curentFile = System.IO.File.ReadAllLines(file.FullName);
                count = System.IO.File.ReadAllLines(file.FullName).Length;
                Console.WriteLine("Файл:\n" + fileName + "\nколичество строк: " + count);


                //if (Path.GetExtension(fileName) == ".zip")
                //{
                //    tmpDir = CreateTempDir();
                //    tmpUnZipDir = UnzipFileToTempDir(file.FullName);
                //    FixDir(tmpUnZipDir.FullName, tmpDir.FullName);
                //    ZipFile.CreateFromDirectory(tmpDir.FullName, @outDir + @"\" + fileName);
                //    tmpDir.Delete(true);
                //    tmpUnZipDir.Delete(true);
                //}
                //else //Path.GetExtension(fileName) <> ".zip"
                //{
                //    fileName = RemoveInvalidFilePathCharacters(fileName, "");
                //    FixBill(@file.FullName, @outDir + @"\" + fileName);
                //}
            }


        }
    }
}
