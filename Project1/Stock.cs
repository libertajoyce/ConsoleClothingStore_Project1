using System;
using System.IO;

namespace Project1
{
    internal class Stock
    {
        public void WriteText(string textToWriteToFile, string path)
        {
            using StreamWriter writer = new StreamWriter(path, true);
            DateTime date = new DateTime();
            date = DateTime.Now;
            writer.WriteLine($"{textToWriteToFile} - {date}");
            writer.Close();
        }

        public void ReadDataFromFile(string path)
        {
            string text = File.ReadAllText(path);
            Console.WriteLine(text);
        }

        //string pizza = "1, Funghi, 9.00, [Tomaat, Mozzarella, Salami, Champignons, Zure room]";
        //string[] pizzaElements = pizza.Split(',');

        //int id = Convert.ToInt32(pizzaElements[0]);
        //string name = pizzaElements[1];
        //double price = Convert.ToDouble(pizzaElements[2]);  

        //int index = pizza.IndexOf('[');

        //string ingredients = pizza.Substring(index + 1);
        //string[] ingredientsArray = ingredients.Split(',');

        //int index = clothes.IndexOf("Tshirt");
        //string tshirt = clothes.Substring(index + 1);
    }
}