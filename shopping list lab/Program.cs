using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Dictionary<string, decimal> menu = new Dictionary<string, decimal>(StringComparer.OrdinalIgnoreCase)
        {
            {"Burger", 5.99M},
            {"Pizza", 8.99M},
            {"Salad", 4.99M},
            {"Fries", 2.99M},
            {"Soda", 1.99M},
            {"Sandwich", 6.99M},
            {"Wrap", 7.99M},
            {"Ice Cream", 3.99M}
        };

        
        List<string> shoppingList = new List<string>();

        
        Console.WriteLine("Welcome to the Chirpus Market!");
        Console.WriteLine();
        Console.WriteLine("Item\t\tPrice");
        Console.WriteLine("=======================");
        foreach (var item in menu)
        {
            Console.WriteLine("{0,-15} ${1,5}", item.Key, item.Value);
        }

        
        while (true)
        {
            Console.Write("Enter an item name (or 'quit' to exit): ");
            string itemName = Console.ReadLine().Trim();

            if (itemName.ToLower() == "quit")
            {
                break;
            }
            else if (menu.ContainsKey(itemName))
            {
                
                shoppingList.Add(itemName);
                Console.WriteLine("{0,-15} ${1,5}", itemName, menu[itemName]);
            }
            else
            {
                Console.WriteLine("Item not found in menu. Please try again.");
                continue;
            }

            
            Console.Write("Add another item? (y/n): ");
            string answer = Console.ReadLine().Trim().ToLower();
            if (answer == "n" || answer == "no")
            {
                break;
            }
        }

        
        Console.WriteLine("\nItems Ordered:");
        decimal totalPrice = 0M;
        foreach (string item in shoppingList)
        {
            Console.WriteLine("{0,-15} ${1,5}", item, menu[item]);
            totalPrice += menu[item];
        }

        
        decimal averagePrice = totalPrice / shoppingList.Count;
        averagePrice = Math.Round(averagePrice, 2);
        
        Console.WriteLine("Total price: ${0}", totalPrice);
        Console.WriteLine("Average price per item: ${0}", averagePrice);
        Console.ReadLine();
    }
}
