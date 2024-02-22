// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using AssetTracking;

// Create sample assets
Laptop macBook = new("MacBook", new DateTime(2024, 10, 15), 1500);
Laptop asus = new("Asus", new DateTime(2023, 2, 28), 1200);
MobilePhone iPhone = new("iPhone", new DateTime(2021, 9, 1), 1000);
MobilePhone samsung = new("Samsung", new DateTime(2022, 1, 10), 900);

// Create  offices
Office newYork = new("New York", "USD");
Office london = new("London", "GBP");
Office tokyo = new("Tokyo", "JPY");

// Store assets in appropriate offices
Dictionary<Office, List<Asset>> officeAssets = new Dictionary<Office, List<Asset>>()
            {
                { newYork, new List<Asset> { macBook, iPhone } },
                { london, new List<Asset> { asus } },
                { tokyo, new List<Asset> { samsung } }
            };

// Print sorted list of assets by office and purchase date
foreach (var office in officeAssets)
{
    Console.WriteLine($"Assets in {office.Key.Name}:");
    office.Value.Sort((a1, a2) => a1.PurchaseDate.CompareTo(a2.PurchaseDate));
    foreach (var asset in office.Value)
    {
        Console.WriteLine($"{asset.ModelName} - Purchase Date: {asset.PurchaseDate.ToShortDateString()} - Status: {asset.EndOfLifeStatus()} - Currency: {office.Key.Currency}");
    }
    Console.WriteLine();
}

namespace AssetTracking
{
    // Define the Asset class as the base class for all assets
    public class Asset
    {
        public string ModelName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }

        public Asset(string modelName, DateTime purchaseDate, decimal price)
        {
            ModelName = modelName;
            PurchaseDate = purchaseDate;
            Price = price;
        }

        // Method to calculate the remaining months until end of life
        public int RemainingMonths()
        {
            TimeSpan timeSpan = DateTime.Now.AddYears(3) - PurchaseDate;
            return (int)(timeSpan.TotalDays / 30);
        }

        // Method to determine if the asset is close to end of life
        public string EndOfLifeStatus()
        {
            int remainingMonths = RemainingMonths();
            if (remainingMonths <= 3)
                return "RED";
            else if (remainingMonths <= 6)
                return "YELLOW";
            else
                return "NORMAL";
        }
    }

    // Define Laptop class inheriting from Asset
    public class Laptop : Asset
    {
        public Laptop(string modelName, DateTime purchaseDate, decimal price) : base(modelName, purchaseDate, price)
        {
        }
    }

    // Define MobilePhone class inheriting from Asset
    public class MobilePhone : Asset
    {
        public MobilePhone(string modelName, DateTime purchaseDate, decimal price) : base(modelName, purchaseDate, price)
        {
        }
    }

    // Define Office class to handle currency conversion
    public class Office
    {
        public string Name { get; set; }
        public string Currency { get; set; }

        public Office(string name, string currency)
        {
            Name = name;
            Currency = currency;
        }
    }
}



