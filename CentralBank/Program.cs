using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, double> exchangeRates = new Dictionary<string, double>()
    {
        { "USD", 18.0 }, // 1 USD = 18 ZAR
        { "EUR", 20.0 }, // 1 EUR = 20 ZAR
        { "GBP", 23.0 }  // 1 GBP = 23 ZAR
    };

    static double inflation = 5.0;       // in percent
    static double interestRate = 7.0;    // in percent
    static double geopoliticalFactor = 1.0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Central Bank Exchange Rate Program");
            Console.WriteLine("1. Display Exchange Rates");
            Console.WriteLine("2. Compare Currency Values");
            Console.WriteLine("3. Update Economic Factors");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    DisplayExchangeRates();
                    break;
                case "2":
                    CompareCurrencyValues();
                    break;
                case "3":
                    UpdateEconomicFactors();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void DisplayExchangeRates()
    {
        Console.WriteLine("Exchange Rates against ZAR:");
        foreach (var rate in exchangeRates)
        {
            Console.WriteLine($"{rate.Key}: {rate.Value}");
        }
    }

    static void CompareCurrencyValues()
    {
        Console.Write("Enter first currency (e.g., ZAR): ");
        string currency1 = Console.ReadLine().ToUpper();
        Console.Write("Enter second currency (e.g., USD): ");
        string currency2 = Console.ReadLine().ToUpper();

        if (exchangeRates.ContainsKey(currency1) && exchangeRates.ContainsKey(currency2))
        {
            double rate1 = exchangeRates[currency1];
            double rate2 = exchangeRates[currency2];

            Console.WriteLine($"{currency1} is worth {rate1 / rate2} {currency2}");
        }
        else
        {
            Console.WriteLine("One or both currencies not found.");
        }
    }

    static void UpdateEconomicFactors()
    {
        Console.Write("Enter new inflation rate (in percent): ");
        inflation = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter new interest rate (in percent): ");
        interestRate = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter new geopolitical factor (as a multiplier): ");
        geopoliticalFactor = Convert.ToDouble(Console.ReadLine());

        AdjustExchangeRates();
        Console.WriteLine("Economic factors updated and exchange rates adjusted.");
    }

    static void AdjustExchangeRates()
    {
        double adjustmentFactor = 1 + (inflation / 100) + (interestRate / 100) * geopoliticalFactor;

        var currencies = new List<string>(exchangeRates.Keys);
        foreach (var currency in currencies)
        {
            exchangeRates[currency] *= adjustmentFactor;
        }
    }
}
