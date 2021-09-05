using System;
using System.Collections.Generic;

namespace OrderPizza
{
    public class Pizza
    {
        public string Name { get; set; }

        public List<Topping> Toppings { get; set; } = new();

        public Size PizzaSize { get; set; }

        public Pizza (string name, List<Topping> toppings, Size pizzaSize)
        {
            this.Name = name;
            this.Toppings = toppings;
            this.PizzaSize = pizzaSize;
        }
    }

    public class Size
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public Size(String name, double price)
        {
            this.Name = name;
            this.Price = price;
        } 
    }

    public class Topping
    {
        public String Name { get; set; }

        public double Price { get; set; }

        public Topping(String name, double price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}