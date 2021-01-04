using System;
using System.Collections.Generic;
using System.Text;
using Project1.enums;

namespace Project1
{
    class Clothes
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public ClothingSize ClothingSize { get; set; }

        public Color Color { get; set; }

        public Gender Gender { get; set; }

        private int PID = 1;
        public int ID { get; set; }

        public Clothes(string name, double price, ClothingSize clothingSize, Color color, Gender gender)
        {
            Name = name;
            Price = price;
            ClothingSize = clothingSize;
            Color = color;
            Gender = gender;
            ID = PID++;

        }

        

       



    }
      
}