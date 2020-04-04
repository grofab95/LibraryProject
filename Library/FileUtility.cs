using System.IO;

namespace Library
{
    public class FileUtility
    {
        public static void SaveToFile(string path, string fileName)
        {
            File.WriteAllText(path, fileName);
        }

        public static string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
