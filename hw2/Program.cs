using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string StringAddress = string.Format(@"D:\Test.txt");
            FileInfo file = new FileInfo(StringAddress);
            StreamWriter writer = file.CreateText();
            for (int i = 0; i < 10; i++)
            {
                writer.WriteLine("Число {0}: {1}", i, i*i);
            }
            writer.Close();
            Console.WriteLine("Файл создан и запись завершена.");
            Console.WriteLine("Нажмите клавишу для чтения файла и вывода данных на экран:");
            Console.ReadKey();
            StreamReader reader = File.OpenText(StringAddress);
            Console.WriteLine(reader.ReadToEnd());
            reader.Close();
            Console.WriteLine("Чтение завершено.");
            Console.ReadKey();
            Console.WriteLine("Нажмите клавишу для удаления файла:");
            try
            {
                file.Delete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Файл удален.");
            Console.ReadKey();
        }
    }
}
