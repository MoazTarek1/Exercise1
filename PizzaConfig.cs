using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace OrderPizza
{
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
            Pizza pepperoniPizza = new("Pepperoni", new(){new("pepperoni", 25), new("Cheese", 15)}, new("n/a", 0));
            Pizza chickenRanchPizza = new("Chicken Ranch", new(){new("Chicken", 25), new("Cheese", 15), new("Ranch", 5)}, new("n/a", 0));
            Pizza margheritaPizza = new("Margherita", new(){new("Extra Cheese", 30)}, new("n/a", 0));
            Pizza seaFoodPizza = new("Sea Food", new(){new("Shrimp", 40), new("Cheese", 15), new("Calamari", 30)}, new("n/a", 0));
            List<Pizza> menu = new(){pepperoniPizza, chickenRanchPizza, margheritaPizza, seaFoodPizza};
            string jsonData = JsonSerializer.Serialize(menu);
            File.WriteAllText(_menu, jsonData);
            return menu;
        }

        public bool SaveCustomOrder(Pizza pizza)
        {
            string jsonData = JsonSerializer.Serialize(pizza);
            if(File.Exists($"Orders/{pizza.Name}.json"))
            {
                return false;
            }
            else
            {
                File.WriteAllText($"Orders/{pizza.Name}.json", jsonData);
                return true;
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
            Topping Calamari = new("Calamari", 30);
            Topping extraCheese = new("Extra cheese", 30);
            Topping Ranch = new("Ranch", 5);
            Topping Cheese = new("Cheese", 15);
            Topping Pepperoni = new("Pepperoni", 25);
            Topping barbeque = new("Barbeque", 5);
            Topping shrimp = new("Shrimp", 40);
            Topping sausage = new("Sausage", 25);
            List<Topping> defaultToppings = new(){chicken, Calamari, extraCheese, Ranch, Cheese, Pepperoni, barbeque, barbeque, shrimp, sausage};
            string jsonData = JsonSerializer.Serialize(defaultToppings);
            File.WriteAllText(_toppings, jsonData);
            return defaultToppings;
        }
    }
}