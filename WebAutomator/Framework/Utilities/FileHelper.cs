using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Utilities
{
    public static class FileHelper
    {
        public static string GetTypeFromFile(string path)
        {
            return path.Split('_')[0];
        }

        public static string GetNameFromFile(string path)
        {
            return path.Split('_')[1];
        }
        public static bool FileExistsInFolder(string filePath, string folderPath)
        {
            string fileName = Path.GetFileName(filePath);
            string combinedPath = Path.Combine(folderPath, fileName);
            return File.Exists(combinedPath);
        }
    }
}
