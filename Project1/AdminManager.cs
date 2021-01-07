using System;
using System.IO;

namespace Project1
{
    internal class AdminManager
    {
        
        public void CreateFile(string file)
        {
            FileStream fileStream = File.Create(file);
            fileStream.Close();
        }

        public void DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        public bool FileExists(string file)
        {
            throw new NotImplementedException();
        }
    }
}