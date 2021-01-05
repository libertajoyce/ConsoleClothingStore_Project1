using Project1.enums;

namespace Project1
{
    internal class Clothes
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public ClothingSize ClothingSize { get; set; }

        public Categorie Category { get; set; }

        public Color Color { get; set; }

        public Gender Gender { get; set; }

        public int ID { get; set; }

        public Clothes()
        {
            //Name = name;
            //Price = price;
            //ClothingSize = clothingSize;
            ////Color = color;
            ////Gender = gender;
        }
    }
}