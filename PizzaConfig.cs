using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace OrderPizza
{
    public enum Size 
    {
            Small = 120,
            Medium = 150,
            Large = 175
    }
    public class PizzaConfig
    {
        private string _menu = "Menu.json";
        private string _toppings = "Toppings.json";

        public List<Pizza> GetMenu()
        {
            try
            { 
                List<Pizza> menu = JsonSerializer.Deserialize<List<Pizza>>(File.ReadAllText(_menu));
                return menu;
            }
            catch
            {
                Console.WriteLine("Failed to read file");
                return DefaultMenu();
            }
        }

        public List<Pizza> DefaultMenu()
        {
            Pizza pepperoniPizza = new("Pepperoni", new(){new("pepperoni", 25), new("Cheese", 15)}, "Unspecified");
            Pizza chickenRanchPizza = new("Chicken Ranch", new(){new("Chicken", 25), new("Cheese", 15), new("Ranch", 5)}, "Unspecified");
            Pizza margheritaPizza = new("Margherita", new(){new("Extra Cheese", 30)}, "Unspecified");
            Pizza seaFoodPizza = new("Sea Food", new(){new("Shrimp", 40), new("Cheese", 15), new("Calamari", 30)}, "Unspecified");
            List<Pizza> menu = new(){pepperoniPizza, chickenRanchPizza, margheritaPizza, seaFoodPizza}; 
            string jsonData = JsonSerializer.Serialize(menu, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
            File.WriteAllText(_menu, jsonData);
            return menu;
        }

        public void SaveOrder(Order order)
        {
            string jsonData = JsonSerializer.Serialize(order, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
            if (!Directory.Exists("Orders"))
            {
                Directory.CreateDirectory("Orders");
            }
            if(File.Exists($"Orders/{order.CustomerName}.json"))
            {
                File.WriteAllText($"Orders/{order.CustomerName}1.json", jsonData);
            }
            else
            {
                File.WriteAllText($"Orders/{order.CustomerName}.json", jsonData);
            }
        }

        public List<Topping> GetToppings()
        {
            try
            { 
                List<Topping> toppings = JsonSerializer.Deserialize<List<Topping>>(File.ReadAllText(_toppings));
                return toppings;
            }
            catch
            {
                Console.WriteLine("Failed to read file");
                return DefaultToppings();
            }
        }

        public List<Topping> DefaultToppings()
        {
            Topping chicken = new("Chicken", 25);
            Topping calamari = new("Calamari", 30);
            Topping extraCheese = new("Extra cheese", 30);
            Topping ranch = new("Ranch", 5);
            Topping cheese = new("Cheese", 15);
            Topping pepperoni = new("Pepperoni", 25);
            Topping barbeque = new("Barbeque", 5);
            Topping shrimp = new("Shrimp", 40);
            Topping sausage = new("Sausage", 25);
            List<Topping> defaultToppings = new(){chicken, calamari, extraCheese, ranch, cheese, pepperoni, barbeque, shrimp, sausage};
            string jsonData = JsonSerializer.Serialize(defaultToppings, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
            File.WriteAllText(_toppings, jsonData);
            return defaultToppings;
        }
    }
}