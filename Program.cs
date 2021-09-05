using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace OrderPizza
{
    class Program
    {
        static void Main(string[] args)
        {
            PizzaConfig menu = new();
            menu.DefaultToppings();
        }
    }
}
