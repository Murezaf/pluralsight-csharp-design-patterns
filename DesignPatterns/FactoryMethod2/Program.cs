using Domain.User;
using FactoryMethod2.Infrastructure;

Console.Title = "Factory Method - Using user info";

var factory = new DiscountFactory();

var user = new User
{
    Country = "Belgium",
    MembershipYears = 6
};

var bestDiscount = factory.CreateBest(user);

Console.WriteLine(
    $"{bestDiscount} => {bestDiscount.DiscountPercentage}%"
);
