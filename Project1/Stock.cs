using Project1.enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project1
{
    internal class Stock
    {
        public List<Clothes> Catalogue { get; set; }

        public Stock()
        {
            Catalogue = new List<Clothes>();

            ReadFile();
        }

        //Owner or admin adds to file still needs modifications
        public void WriteText(string textToWriteToFile, string path) 
        {
            using StreamWriter writer = new StreamWriter(path, true);
            DateTime date = new DateTime();
            date = DateTime.Now;
            writer.WriteLine($"{textToWriteToFile} - {date}");
            writer.Close();
        }


        // Adds a new clothing item to in memory database
        public void AddClothing(Clothes item)
        {
            item.ID = Catalogue.Count + 1;
            Catalogue.Add(item);
        }

        public void ShowItems()
        {
            foreach (var item in Catalogue)
            {
                Console.WriteLine($"{item.Name} - {item.ID}");
            }
        }

        public void ShowItemsFiltered(string userChoice)
        {
            var choice = ConvertCategorie(userChoice);
            
            foreach (var item in Catalogue)
            {
                if (item.Category == choice)
                {
                    Console.WriteLine($"               " +
                    $"{ item.ID}) { item.Name}");
                }
            }
            
        }
        

        

        public void ReadFile()
        {
            //This is how it will read file into memory database:
            string[] lines = File.ReadAllLines("C:/users/emmad/source/repos/Project1/Project1/Inventory.txt"); //ADD PATH

            for (int i = 1; i < lines.Length; i++)
            {
                string catalogueLine = lines[i];
                string[] data = catalogueLine.Split(',');
                Clothes item = new Clothes
                {
                    ID = Convert.ToInt32(data[0]),
                    Category = ConvertCategorie(data[1]),
                    Name = data[2],
                    Price = Convert.ToDouble(data[3])
                };
                Catalogue.Add(item);
            }
        }
        public Categorie ConvertCategorie(string categoryID)
        {
            switch (categoryID)
            {
                case "0":
                    return Categorie.Tshirt;

                case "1":
                    return Categorie.Longsleeve;

                case "2":
                    return Categorie.Jeans;

                case "3":
                    return Categorie.DressPants;

                case "4":
                    return Categorie.Dress;

                case "5":
                    return Categorie.Sweater;

                case "6":
                    return Categorie.Pyjama;

                case "7":
                    return Categorie.Intimates;

                default:
                    return Categorie.Misc;
            }
        }
    }
}
