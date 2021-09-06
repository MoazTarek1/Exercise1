using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using Spectre.Console;

namespace OrderPizza
{
    public class Window
    {
        public string DrawMainMenu()
        {
            AnsiConsole.Clear();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Start you order", "Exit"
            }));
            return userChoice;
        }

        public (int, string) DrawTakingOrder()
        {
            AnsiConsole.Clear();
            string customerName = AnsiConsole.Ask<string>("What's your name?");   
            int numberOfPizza = AnsiConsole.Ask<int>("How many pizzas would you like to order?"); 
            return (numberOfPizza, customerName);          
        }
        
        public string DrawCustomOrMenu()
        {
            AnsiConsole.Clear();
            var userChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Pizza from menu or custom pizza?:")
                    .PageSize(10)
                    .AddChoices(new[]{
                        "Pizza from menu",
                        "Custom made pizza"
            }));
            return userChoice;                
        }

        public string DrawSizeSelect()
        {
            AnsiConsole.Clear();
            var pizzaSize = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose a size:")
                    .PageSize(10)
                    .AddChoices(new[] {"Small", "Medium", "Large"}
            ));
            return pizzaSize;  
        }

        public Pizza DrawMenuPizzaSelect(List<Pizza> pizzaMenu)
        {
            AnsiConsole.Clear();
            Pizza selectedPizza = AnsiConsole.Prompt(
                new SelectionPrompt<Pizza>()
                    .Title("Choose a pizza:")
                    .PageSize(10)
                    .AddChoices(pizzaMenu)
            );
            string pizzaSize = this.DrawSizeSelect();
            Pizza pizza = new(selectedPizza.Name, selectedPizza.Toppings, pizzaSize);
            return pizza;     
        }    

        public Pizza DrawCustomPizzaSelect(List<Topping> listOfToppings)
        {
            AnsiConsole.Clear();
            var toppings = AnsiConsole.Prompt(
                new MultiSelectionPrompt<Topping>()
                    .Title("Choose your toppings:")
                    .PageSize(10)
                    .MoreChoicesText("[grey](Move up and down to reveal more toppings)[/]")
                    .InstructionsText(
                        "[grey](Press [blue]<space>[/] to toggle a topping, " + 
                        "[green]<enter>[/] to accept)[/]")
                    .AddChoices(listOfToppings)
            );
            var pizzaName = AnsiConsole.Ask<string>("What do you want to name your pizza?");
            string pizzaSize = this.DrawSizeSelect();
            Pizza pizza = new(pizzaName, listOfToppings, pizzaSize);
            return pizza;
        } 
    }
}