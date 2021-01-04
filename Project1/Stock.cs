using System;
using System.Collections.Generic;
using System.IO;

namespace Project1
{
    internal class Stock
    {
        public void WriteDataToFile(string[] lines, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            foreach (string listLines in lines)
            {
                writer.WriteLine(listLines);
            }
        }

        public List<string> ReadDataFromFile(string path)
        {
            //throw new NotImplementedException();
            string line = string.Empty;
            using StreamReader reader = new StreamReader(path);
            List<string> lines = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        public void CopyData(string fromPath, string toPath)
        {
            List<string> lines = ReadDataFromFile(fromPath);

            lines.RemoveAt(2);
            lines.Sort();
            lines.RemoveAt(lines.Count - 1);
            lines.Add("I'm the last of my kind.");
            lines.ToArray();

            WriteDataToFile(lines.ToArray(), toPath);
        }

        
    }
}