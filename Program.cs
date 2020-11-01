using System;
using System.IO;
using System.Text;


namespace CsTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string folder_path = path + "/Folder";
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyyMMdd");
            string date_text = dt.ToString("HH:mm:ss");
            string file_path = folder_path + "/" + date + ".txt";


            Console.WriteLine("テキストを入力してください");
            var line = System.Console.ReadLine();


            if (Directory.Exists(folder_path))
            {
                //Console.WriteLine("存在します");
            }
            else
            {
                Console.WriteLine("存在しないので作成します");

                DirectoryInfo di = new DirectoryInfo(folder_path);
                di.Create();
            }


            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(file_path))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(date_text + "\n" + line);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            //Console.WriteLine(line);
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
