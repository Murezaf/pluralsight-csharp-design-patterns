using FactoryMethod.Domain;
using FactoryMethod.Infrastructure;

Console.Title = "Factory Method";

List<DiscountFactory> factories = new List<DiscountFactory>() { new CountryDiscountFactory("Belgium"),
    new CountryDiscountFactory("Germany"), new CodeDiscountFactory(new Guid()) };

foreach(DiscountFactory factory in factories)
{
    DiscountService discountService = factory.CreateDiscountService();
    Console.WriteLine($"Discount Persentage: {discountService.DiscountPersentage} comming from: {discountService}");
}