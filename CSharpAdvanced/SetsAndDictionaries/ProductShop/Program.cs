using System;
using System.Collections.Generic;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            
            SortedDictionary<string, Dictionary<string, double>> dictionary = 
                new SortedDictionary<string, Dictionary<string, double>>(); 
            while((input = Console.ReadLine()) != "Revision")
            {
                 string[] inputIndex = input.Split(", ");
                 string shop = inputIndex[0];
                 string product = inputIndex[1];
                 double price = double.Parse(inputIndex[2]);
                if(!dictionary.ContainsKey(shop)) 
                {
                    dictionary.Add(shop,new Dictionary<string, double>());
                }
                dictionary[shop][product] = price;
            }
            foreach(var shop in dictionary) 
            {
                Console.WriteLine($"{shop.Key}->");
                foreach(var product in shop.Value) 
                {
                    Console.Write($"Product: {product.Key}, Price: {product.Value} ");
                    Console.WriteLine();
                }
                
                
            }
        }
    }
}
