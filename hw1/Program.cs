using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"D:\");
            if (directory.Exists)
            {
                DirectoryInfo HwDirectory = directory.CreateSubdirectory(@"hw");
                if (HwDirectory.Exists)
                {
                    for (int i = 1; i <= 50; i++)
                    {
                        string adress = string.Format("Folder_{0}", i);
                        DirectoryInfo NewFolde = HwDirectory.CreateSubdirectory(adress);
                        Console.WriteLine("FullName    : {0}", NewFolde.FullName);
                        Console.WriteLine("Name        : {0}", NewFolde.Name);
                        Console.WriteLine("Parent      : {0}", NewFolde.Parent);
                        Console.WriteLine("CreationTime: {0}", NewFolde.CreationTime);
                        Console.WriteLine("Attributes  : {0}", NewFolde.Attributes.ToString());
                        Console.WriteLine("Root        : {0}", NewFolde.Root);
                        Console.WriteLine(new string('-', 15));
                        Console.WriteLine("Каталоги успешно созданы.");

                    }
                }
            }
            else
            {
                Console.WriteLine("Директория с именем: {0}  не существует.", directory.FullName);
            }
            Console.WriteLine("Нажмите enter для удаления каталогов:");
            Console.ReadKey();
            try
            {
                Directory.Delete(@"D:\hw", true);
                Console.WriteLine("Каталоги успешно удалены.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
