using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    class Program
    {
        static void Main(string[] args)
        {
filename:   Console.Write("Введите имя или часть имени файла: ");
            string FileName = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);
            string[] files = null;
            try
            {
                files = Directory.GetFiles(@"D:\test\", string.Format("*{0}*", FileName), SearchOption.AllDirectories);
                if (files.Length == 0)
                {
                    
                    Console.WriteLine("Совпадений не найдено. Повторите попытку");
                    goto filename;
                }
                else
                {
                    Console.WriteLine("Найденое количество совпадений: {0}.", files.Length);
                }  
                int counter = 0;
                foreach (string file in files)
                {
                    counter++;
                    Console.WriteLine("{0}. {1}", counter, file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: {0}", e.ToString());
            }
            Console.WriteLine(Environment.NewLine);
            Console.Write("Выберите номер файл с которым хотите продолжить работу: ");
            int FileNumber = 0;
            try
            {
                FileNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.WriteLine($"Выбраный файл: {files[FileNumber]}");
                Console.WriteLine(Environment.NewLine);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            firststep: Console.Write("Выберите один из вариантов:\n" +
                           "1. Считать файл и вывести на экран;\n" +
                           "2. Заархивировать файл;\n" +
                           "3. Выход из программы.\n" +
                           "Ваш выбор: ");
            int value = 0;
            try
            {
                value = Convert.ToInt32(Console.ReadLine()); 
                Console.Write(Environment.NewLine);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Нажмите enter для продолжения");
                Console.ReadKey();
                goto firststep;
            }

            Console.WriteLine(Environment.NewLine);
            switch (value)
            {
                case 1:
                    {
                        FileStream fs = new FileStream(files[FileNumber], FileMode.Open, FileAccess.Read);
                        byte[] array = null;
                        using (fs = File.OpenRead(files[FileNumber]))
                        {
                            array = new byte[files[FileNumber].Length];
                            fs.Read(array, 0, array.Length);
                            string ByteToString = Encoding.Default.GetString(array);
                            Console.WriteLine($"Текст из файла: \n{ByteToString}");
                        }
                        Console.WriteLine("Нажмите enter для продолжения");
                        Console.WriteLine(Environment.NewLine);
                        Console.ReadKey();

                        goto firststep;
                    }
                case 2:
                    {
                        FileStream source = File.OpenRead(files[FileNumber]);
                        DirectoryInfo fi = new DirectoryInfo(files[FileNumber]);
                        string fileZIP = String.Format($@"{fi.Parent.FullName}\{Path.GetFileNameWithoutExtension(fi.Name)}.zip");
                        if (!File.Exists(fileZIP))
                        {
                            FileStream destination = File.Create(fileZIP);
                            GZipStream compressor = new GZipStream(destination, CompressionMode.Compress);
                            int theByte = source.ReadByte();
                            while (theByte != -1)
                            {
                                compressor.WriteByte((byte)theByte);
                                theByte = source.ReadByte();
                            }
                            compressor.Close();
                            Console.WriteLine("Архивация завершена.");
                            Console.WriteLine($"Адресс архива: {destination.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Архив с таким мименем уже существует.");
                        }
                        Console.WriteLine("Нажмите enter для продолжения");
                        Console.WriteLine(Environment.NewLine);
                        Console.ReadKey();
                        goto firststep;
                    }
                case 3:
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
