namespace ShoppingCartTemplateMethod;

public class OrderItem
{
    public OrderItem(int itemId, decimal unitPrice, int quantity)
    {
        ItemId = itemId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public int ItemId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
}

//AbstractClass
public abstract class AbstractShoppingCart
{
    private readonly List<OrderItem> _orderitems = new List<OrderItem>();

    public void AddItem(int itemId, decimal unitPrice, int quantity)
    {
        _orderitems.Add(new OrderItem(itemId, unitPrice, quantity));
    }

    public decimal CalculatePrice()
    {
        decimal price = 0;
        foreach (var item in _orderitems)
            price += item.UnitPrice * item.Quantity;

        return price;
    }

    public abstract decimal ApplyDiscount();

    public abstract decimal ShippingCost();

    public virtual void SendingProcess()
    {
        Console.WriteLine($"Your order is now getting ready to send contains {_orderitems.Count} items.");
    }

    //TemplateMethod
    public void ConfirmYourOrder()
    {
        decimal totalPrice = CalculatePrice();
        decimal discount = ApplyDiscount();
        decimal shippingCost = ShippingCost();
        SendingProcess();
        Console.WriteLine($"Your final order price is {totalPrice * (1 - discount) + shippingCost}");
    }
}

//ConcreteClass
public class StandardShoppingCart : AbstractShoppingCart
{
    public override decimal ApplyDiscount() => 0.1m;

    public override decimal ShippingCost() => 20m;
}

//ConcreteClass
public class BlackFridayShoppingCart : AbstractShoppingCart
{
    public override decimal ApplyDiscount() => 0.4m;

    public override decimal ShippingCost() => 10m;
}

//ConcreteClass
public class LocalShoppingCart : AbstractShoppingCart
{
    public override decimal ApplyDiscount() => 0;

    public override decimal ShippingCost() => 0;

    public override void SendingProcess()
    {
        Console.WriteLine("unfortunately right now we don't have any delivery service. You should pickup your orders by your own. We email you our current address.");   
    }
}
