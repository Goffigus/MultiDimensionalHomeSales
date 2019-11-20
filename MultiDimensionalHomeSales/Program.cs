using System;
using static System.Console;

namespace MultiDimensionalHomeSales
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString;
            string letter;
            double sale, grandTotal;

            string[,] employees = { { "Danielle", "Edward", "Francis", "Alex" },
                                        {"d", "e", "f" ,"a" },
                                           {"0","0","0","0"} };


            
            //get the user input and set it to lowercase
            Write("Enter a salesperson initial >> ");
            inputString = ReadLine();
            inputString = inputString.ToLower();
            letter = inputString;

            int post; 
            while (letter != "z")
            {
                Write("Enter amount of sale >> ");
                inputString = ReadLine();
                sale = Convert.ToDouble(inputString);

                post = -1;
                for(int x = 0; x < employees.GetLength(1); ++x)
                {
                    if(employees[1,x] == letter)
                    {
                        post = x;
                    }
                }
                if (post >= 0)
                {
                    double total = Convert.ToDouble(employees[2, post]);
                    total += sale;
                    employees[2, post] = total.ToString();
                }    
                else
                    WriteLine("Sorry - invalid salesperson.");

                Write("Enter next salesperson intital Z to quit >> ");
                inputString = ReadLine();
                inputString = inputString.ToLower();
                letter = inputString;
                
            }

            //prints out the employees names with their totals
            for (int x = 0; x < employees.GetLength(1); ++x)
            {
                WriteLine("{0} sold    {1,10}", employees[0,x], employees[2, x]);
            }

            //gets the grandtotal
            grandTotal = 0;
            for (int x = 0; x < employees.GetLength(1); ++x)
            {
                double total = Convert.ToDouble(employees[2, x]);
                grandTotal += total;
            }
            WriteLine("Total sales were {0,10}", grandTotal.ToString("C"));

            //finds the person with the most sales
            int mostSales = 0;
            for (int x = 1; x < employees.GetLength(1); ++x)
            {
                double total = Convert.ToDouble(employees[2, x]);
                double mTotal = Convert.ToDouble(employees[2, mostSales]);
                if (total > mTotal)
                {
                    mostSales = x;
                }
            }

            WriteLine("{0} sold the most", employees[0,mostSales]);
        }
    }
}
