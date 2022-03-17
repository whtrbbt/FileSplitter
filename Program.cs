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
            int linesCount = 0;
            int fileCount = 0;


            foreach (FileInfo file in dirIN.GetFiles())
            {
                string[] curentFile;
                int outFileNum = 0;
                string outFileName = "";
                string[] buffer = new String[linesQ];
                fileName = Path.GetFileName(file.FullName);
                Console.WriteLine(fileName);
                curentFile = System.IO.File.ReadAllLines(file.FullName);
                linesCount = curentFile.Length;
                int lineCounter = 0;
                Console.WriteLine("Файл:\n" + fileName + "\nколичество строк: " + linesCount);
                

                //определяем итоговое кол-во файлов
                //fileCount = linesCount / linesQ;
                //if (linesCount % linesQ > 0)
                //    fileCount++;

                //try
                //{
                //    File.Create(@outFileName);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.ToString());
                //}

                foreach (string line in curentFile)
                { 

                    buffer[lineCounter] = line;
                    ++lineCounter;
                    if ((lineCounter) == linesQ)
                    {
                        //if (!File.Exists(@outFileName))
                        //{
                        ++outFileNum;
                        outFileName = dirOUT + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_" + outFileNum + Path.GetExtension(fileName);
                        File.WriteAllLines(@outFileName, buffer);
                        Array.Clear(buffer,0,linesQ);
                        lineCounter = 0;                         
                        Console.WriteLine("Исходящий файл: " + outFileName);
                        //}

                    }
                }

                if ((lineCounter) > 0)
                {
                    ++outFileNum;
                    outFileName = dirOUT + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_" + outFileNum + Path.GetExtension(fileName);
                    Console.WriteLine("Исходящий файл: " + outFileName);
                    File.WriteAllLines(@outFileName, buffer);
                    Array.Clear(buffer, 0, linesQ);
                    lineCounter = 0;
                }


                    //foreach (string str in curentFile)
                    //{
                    //    Console.WriteLine(str);
                    //}

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
