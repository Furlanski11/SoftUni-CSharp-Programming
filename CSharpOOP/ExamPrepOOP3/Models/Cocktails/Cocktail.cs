using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        public IReadOnlyCollection<string> cocktailSizes = new List<string>() { "Small", "Middle", "Large" };
        private string name;
        private string size;
        private double price;

        public Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

        public double Price
        {
            get { return price; }
            private set
            {
                switch (Size)
                {
                    case "Large":
                        price = value;
                        break;
                    case "Middle":
                        price = (value / 3) *2;
                        break;
                    case "Small":
                        price = value / 3;
                        break;
                }
                
            }
        }
        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }

    }
}
