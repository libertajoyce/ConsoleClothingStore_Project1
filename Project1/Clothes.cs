﻿using Project1.enums;

namespace Project1
{
    internal class Clothes
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public Categorie Category { get; set; }

        public ClothingSize ClothingSizes { get; set; }

        public Color ColorOptions { get; set; }

        public int ID { get; set; }
    }
}