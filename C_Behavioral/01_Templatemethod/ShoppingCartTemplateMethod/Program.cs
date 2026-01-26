using ShoppingCartTemplateMethod;

Console.Title = "ShoppingCartTemplateMethod";

StandardShoppingCart standardShoppingCart = new StandardShoppingCart();
standardShoppingCart.AddItem(1, 150, 10);
standardShoppingCart.AddItem(2, 480, 5);
standardShoppingCart.ConfirmYourOrder();
Console.WriteLine();

BlackFridayShoppingCart blackFridayShoppingCart = new BlackFridayShoppingCart();
blackFridayShoppingCart.AddItem(1, 150, 10);
blackFridayShoppingCart.AddItem(2, 480, 5);
blackFridayShoppingCart.ConfirmYourOrder();
Console.WriteLine();

LocalShoppingCart localShoppingCart = new LocalShoppingCart();
localShoppingCart.AddItem(1, 150, 10);
localShoppingCart.AddItem(2, 480, 5);
localShoppingCart.ConfirmYourOrder();
Console.WriteLine();