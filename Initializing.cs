using System.IO;

namespace ConsoleApp1
{
    class Initializing
    {
        public static void FolderCheck()
        {
            string path = Directory.GetCurrentDirectory();
            if (Directory.Exists(path + @"Users") == false)
            {
                Directory.CreateDirectory(path + @"Users");
            }
            if (Directory.Exists(path + @"Match History") == false)
            {
                Directory.CreateDirectory(path + @"Match History");
            }
            if (File.Exists(path + @"Table Counter.txt") == false)
            {
                File.WriteAllText(path + @"Table Counter.txt", "0");
            }
        }
    }
}
