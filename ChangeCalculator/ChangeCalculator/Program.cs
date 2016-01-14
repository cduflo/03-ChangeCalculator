using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator
{
    class Program
    {
        //Method to fetch and validate user input
        static decimal GetDouble(string prompt)
        {
            Console.WriteLine(prompt);
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    decimal x = decimal.Parse(input);
                    x = decimal.Round(x, 2, MidpointRounding.AwayFromZero);
                    if (x > 0)
                    {
                        return x;
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a positive amount.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: Please enter a valid amount.");
                }
            }
        }

        //Define class to hold change variables defined in Main
        class Money
        {
            public decimal amount { get; set;  }
            public string print { get; set; }
        }

        static void Main(string[] args)
        {
            //Set change types
            List<Money> changeMoney = new List<Money>
                {
                new Money { amount = 100, print = "Hundred Dollar Bills: " },
                new Money { amount = 50, print = "Fifty Dollar Bills: " },
                new Money { amount = 20, print = "Twenty Dollar Bills: "},
                new Money { amount = 10, print = "Ten Dollar Bills: " },
                new Money { amount = 5, print = "Five Dollar Bills: " },
                new Money { amount = 1, print = "One Dollar Bills: " },
                new Money { amount = .25M, print = "Quarters: " },
                new Money { amount = .10M, print = "Dimes: " },
                new Money { amount = .05M, print = "Nickles: " },
                new Money { amount = .01M, print = "Pennies: " }
                };

            //Set key variables and fetch user input
            decimal cost = GetDouble("How much does the item cost?");
            Console.WriteLine();
            decimal given = GetDouble("How much has the customer given you?");
            Console.WriteLine();

            //Compute customer change
            decimal totalChange = given - cost;
            Console.WriteLine("The customer's change is: $" + totalChange);

            //Set variable for reducing totalChange amount in following loop
            decimal remaining = totalChange;

            //Loop through changeMoney and print proper change to Console
            for ( var i = 0; i < changeMoney.Count; i++)
            {
                decimal y = Convert.ToInt32(Math.Floor(remaining / changeMoney[i].amount));
                if (y>0)
                {
                    Console.WriteLine(changeMoney[i].print + y);
                }
                remaining = remaining % changeMoney[i].amount;
            }

            Console.ReadLine();
            /* Original Theory
            //Compute Amount of Change which should be paid in 100 dollar bills
            decimal hundredBill = Math.Floor(totalChange / 100);
            if (hundredBill > 0)
            {
                Console.WriteLine("Hundred Dollar Bills: " + hundredBill);
            }
            decimal remaining = totalChange % 100;*/
        }
    }
}
