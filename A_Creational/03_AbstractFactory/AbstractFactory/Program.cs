using static AbstractFactory.Implementation;

Console.Title = "Abstract Factory";

BelgiumShoppingCartPurchaseFactory belgiumShoppingCartPurchaseFactory = new BelgiumShoppingCartPurchaseFactory();
ShoppingCart shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPurchaseFactory);

shoppingCartForBelgium.CalculateCosts();

FranceShoppingCartPurchaseFactory franceShoppingCartPurchaseFactory = new FranceShoppingCartPurchaseFactory();
ShoppingCart shoppingCartForFrance = new ShoppingCart(franceShoppingCartPurchaseFactory);

shoppingCartForFrance.CalculateCosts();