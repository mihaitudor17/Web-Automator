using Framework.Utilities;

namespace Testing.Utils
{
    public static class FileDictionary
    {
        static FileDictionary()
        {
            var files = Directory.GetFiles(Path.GetFullPath(Constants.Resources), "*", SearchOption.TopDirectoryOnly);
            files.ToList().ForEach(file => FileDict.Add(FileHelper.GetNameFromFile(file), file));
        }
        public static Dictionary<string,string> FileDict = new Dictionary<string,string>();
    }
}
