using System;
using System.IO;

namespace NsTools.Useful.Has
{
    public class Exists
    {
        private bool Result { get; set; }
        private DirectoryInfo Folders { get; set; }
        private string PathFolder { get; set; }
        private string NameFile { get; set; }

        public Exists(string pathFolder, string nameFile)
        {
            Result = false;
            Folders = new DirectoryInfo(pathFolder);
            NameFile = nameFile;
        }
        public bool SearchCheckFileExist()
        {
            foreach (DirectoryInfo folder in Folders.GetDirectories())
            {
                try
                {
                    foreach (FileInfo file in folder.GetFiles(NameFile, SearchOption.AllDirectories))
                    {
                        if (NameFile.Contains(file.Name))
                        {
                            Result = true;
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
            return Result;
        }
    }
}
