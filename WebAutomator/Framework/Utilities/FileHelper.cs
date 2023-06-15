namespace Framework.Utilities
{
    public static class FileHelper
    {
        public static string GetTypeFromFile(string path)
        {
            return path.Split('\\').Last().Split('_').First();
        }

        public static string GetNameFromFile(string path)
        {
            return path.Split('_').Last().Split('.').First();
        }

        public static bool FileExistsInTemp(string filePath, string folderPath)
        {
            string fileName = Path.GetFileName(filePath);
            string combinedPath = Path.Combine(folderPath, fileName);
            return File.Exists(combinedPath);
        }
    }
}
