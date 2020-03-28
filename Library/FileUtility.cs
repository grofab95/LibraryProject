using System.IO;

namespace Library
{
    public class FileUtility
    {
        public static void SaveFile(string fileName)
        {
            File.WriteAllText(Variable.FILENAMEPATH, fileName);
        }

        public static string ReadFile()
        {
            return File.ReadAllText(Variable.FILENAMEPATH);
        }
    }
}
