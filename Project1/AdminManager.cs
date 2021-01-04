using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1
{
    class AdminManager
    {
        public void CreateFile(string file)
        {
            //throw new NotImplementedException();
            FileStream fileStream = File.Create(file);
            fileStream.Close();
        }

        public void DeleteFile(string file)
        {
            //throw new NotImplementedException();
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
