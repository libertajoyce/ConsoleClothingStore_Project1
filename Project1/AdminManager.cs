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
        //readerWriter.CopyData(filePath, filePath2);
        //fileManager.DeleteFile(filePath);

        //public void CopyData(string fromPath, string toPath)
        //{
        //    List<string> lines = ReadDataFromFile(fromPath);
        //    int remover = Convert.ToInt32(Console.ReadLine());
        //    lines.RemoveAt(remover);
        //    lines.Add("I'm the last of my kind.");
        //    lines.ToArray();

        //    WriteDataToFile(lines.ToArray(), toPath);
        //}
    }
}