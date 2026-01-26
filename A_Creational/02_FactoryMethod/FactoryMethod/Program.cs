using FactoryMethod;

Console.Title = "Factory Method";

CodeDiscountFactory codeDiscountFactory = new CodeDiscountFactory(new Guid());
CountryDiscountFactory countryDiscountFactory = new CountryDiscountFactory("Belgium");

List<DiscountFactory> factories = new List<DiscountFactory>();
factories.Add(codeDiscountFactory);
factories.Add(countryDiscountFactory);

foreach (DiscountFactory factory in factories)
{
    DiscountService discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} coming from {discountService}");
}