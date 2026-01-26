using Facade;

Console.Title = "Facade";

DiscountFacade facade = new DiscountFacade();

Console.WriteLine($"Discount percentage for customer with Id 1: {facade.CalculateDiscountPercentage(1)}.");
Console.WriteLine($"Discount percentage for customer with Id 10: {facade.CalculateDiscountPercentage(10)}.");