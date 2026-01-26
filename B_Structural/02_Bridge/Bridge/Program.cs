using Bridge;

Console.Title = "Bridge";

ICoupon noCoupon = new NoCoupon();
ICoupon oneEuroCoupon = new OneEuroCoupon();

MeatBasedMenu meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu, no coupon: {meatBasedMenu.CalculatePrice()} euros.");

meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu, one euro coupon: {meatBasedMenu.CalculatePrice()} euros.");

VegetarianMenu vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"Vegetarian menu, no coupon: {vegetarianMenu.CalculatePrice()} euros.");

vegetarianMenu = new VegetarianMenu(oneEuroCoupon);
Console.WriteLine($"Vegetarian menu, one euro coupon: {vegetarianMenu.CalculatePrice()} euros.");