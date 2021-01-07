using Project1.enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace Project1
{
    internal class Stock
    {
        private string filePath = "C:/users/emmad/source/repos/Project1/Project1/Inventory.txt";
        private string filePath2 = "C:/users/emmad/source/repos/Project1/Project1/Inventory.txt";
        public List<Clothes> Catalogue { get; set; }

        public Stock()
        {
            Catalogue = new List<Clothes>();

            ReadFile();
        }

        //Owner or admin adds to file
        public void OwnerWriteText()
        {
            using StreamWriter writer = new StreamWriter(filePath, true);
            Clothes item = new Clothes();

            Console.WriteLine("Enter the name of the clothing:");
            item.Name = Console.ReadLine();
            Console.WriteLine("Name added, succesfully!");

            Console.WriteLine("Enter the category:\n1.Tshirts\n2.Longsleeves\n3.Jeans\n4.Dress Pants\n5. Dress\n6. Sweater\n7. Pyjama\n8. Intimates\n9. Misc");
            string categoryChoice = Console.ReadLine();
            item.Category = ConvertCategorie(categoryChoice);
            Console.WriteLine("Category added, succesfully!");

            Console.WriteLine("Enter the size:\n1. XS\n2. S\n3. M\n4. L\n5. XXL\n6. TU");
            string clothingSizeChoice = Console.ReadLine();
            item.ClothingSizes = ConvertClothingSize(clothingSizeChoice);
            Console.WriteLine("Size added, succesfully!");

            Console.WriteLine("Enter the color:\n1. Blue\n2. Black\n3. Red\n4. Green\n5. Yellow\n6. Pink\n7. White\n8. Gold\n9. Silver");
            string colorChoice = Console.ReadLine();
            item.ColorOptions = ConvertColor(colorChoice);
            Console.WriteLine("Color added, succesfully!");

            Console.WriteLine("Enter the price of that piece of clothing:");
            item.Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Price added, succesfully!");
            item.ID = Catalogue.Count + 1;
            Catalogue.Add(item);
            writer.Write($"\n{item.ID},{categoryChoice},{item.Name},{item.Price:#.##}");

            writer.Close();
        }

        public void OwnerDeleteText()
        {
            int remover = 0;
            int ID = 1;
            foreach (var item in Catalogue)
            {
                item.ID = ID;
                Console.WriteLine($"               " +
                $"{item.ID} { item.Name} Size:{item.ClothingSizes} Color:{item.ColorOptions} €{item.Price}");
                ID++;
            }
            Console.WriteLine($"Enter the ID of the item you want to delete:");
            List<string> lines = ReadDataFromFile(filePath);
            remover = Convert.ToInt32(Console.ReadLine());

            lines.RemoveAt(remover);
            lines.ToArray();
            Catalogue.RemoveAt(remover - 1);
            Methods.Cart.RemoveAt(remover - 1);
            DeleteFile(filePath);
            WriteDataToFile(lines.ToArray(), filePath2);
        }

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
            using StreamReader reader = new StreamReader(path);
            List<string> lines = new List<string>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines;
        }

        public void DeleteFile(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        public void ShowItemsFiltered(string userCategorieChoice)
        {
            var categoryChoice = ConvertCategorie(userCategorieChoice);
            int ID = 1;
            foreach (var item in Catalogue)
            {
                if (item.Category == categoryChoice)
                {
                    item.ID = ID;
                    Console.WriteLine($"               " +
                    $"{item.ID} { item.Name} Size:{item.ClothingSizes} Color:{item.ColorOptions} €{item.Price}");
                }
                ID++;
            }
        }

        public void ReadFile()
        {
            //This is how it will read file into memory database:
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 1; i < lines.Length; i++)
            {
                string catalogueLine = lines[i];
                string[] data = catalogueLine.Split(',');
                Clothes item = new Clothes
                {
                    ID = Convert.ToInt32(data[0]),
                    Category = ConvertCategorie(data[1]),
                    Name = data[2],
                    ClothingSizes = ConvertClothingSize(data[3]),
                    ColorOptions = ConvertColor(data[4]),
                    Price = Convert.ToDouble(data[5])
                };
                Catalogue.Add(item);
            }
        }

        public Categorie ConvertCategorie(string categoryID)
        {
            switch (categoryID)
            {
                case "1":
                    return Categorie.Tshirt;

                case "2":
                    return Categorie.Longsleeve;

                case "3":
                    return Categorie.Jeans;

                case "4":
                    return Categorie.DressPants;

                case "5":
                    return Categorie.Dress;

                case "6":
                    return Categorie.Sweater;

                case "7":
                    return Categorie.Pyjama;

                case "8":
                    return Categorie.Intimates;

                default:
                    return Categorie.Misc;
            }
        }

        public ClothingSize ConvertClothingSize(string clothingID)
        {
            switch (clothingID)
            {
                case "1":
                    return ClothingSize.XS;

                case "2":
                    return ClothingSize.S;

                case "3":
                    return ClothingSize.M;

                case "4":
                    return ClothingSize.L;

                case "5":
                    return ClothingSize.XL;

                case "6":
                    return ClothingSize.XXL;

                default:
                    return ClothingSize.TU;
            }
        }

        public Color ConvertColor(string colorID)
        {
            switch (colorID)
            {
                case "1":
                    return Color.Blue;

                case "2":
                    return Color.Black;

                case "3":
                    return Color.Red;

                case "4":
                    return Color.Green;

                case "5":
                    return Color.Yellow;

                case "6":
                    return Color.Pink;

                case "7":
                    return Color.White;

                case "8":
                    return Color.Gold;

                default:
                    return Color.Silver;
            }
        }
    }
}