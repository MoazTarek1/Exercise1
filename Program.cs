using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Spectre.Console;

namespace OrderPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaConfig pizzaConfig = new();
            Window window = new();
            var userSelection = window.DrawMainMenu();
            
            while (userSelection != "Exit")
            {
                List<Pizza> pizzas = new(); 
                (int numberOfPizza, string customerName) = window.DrawTakingOrder();
                for (int i = 0; i < numberOfPizza; i++)
                {
                    var orderType = window.DrawCustomOrMenu();
                    if (orderType == "Pizza from menu")
                    {
                        pizzas.Add(window.DrawMenuPizzaSelect(pizzaConfig.GetMenu()));
                    }
                    else if (orderType == "Custom made pizza")
                    {
                        pizzas.Add(window.DrawCustomPizzaSelect(pizzaConfig.GetToppings()));
                    }                    
                }
                Order order = new(customerName, pizzas);
                pizzaConfig.SaveOrder(order);
                userSelection = window.DrawMainMenu();
            }    
        }
    }
}
