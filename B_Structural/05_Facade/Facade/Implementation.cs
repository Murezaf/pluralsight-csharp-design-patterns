namespace Facade;

//SubsystemClasses: fake calculations for demo purposes
public class OrderService
{
    public bool HasEnoughOrders(int customerId)
    {
        return customerId > 5;
    }
}

public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId)
    {
        return customerId > 8 ? 10 : 20;
        //Can be based on customer country, number of orders, total order price and so on 
    }
}

public class DayOfTheWeekFactorService
{
    public double CalculateDayOfTheWeekFactor()
    {
        switch(DateTime.UtcNow.DayOfWeek)
        {
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                return 0.8;

            default:
                return 1.2;

        }
    }
}

//Facade
public class DiscountFacade
{
    private readonly OrderService _orderService = new OrderService();
    private readonly CustomerDiscountBaseService _customerDiscountBaseService = new CustomerDiscountBaseService();
    private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new DayOfTheWeekFactorService();
    //They could be added via DI and IoCContainer. We could also add the constructor and let the Client class(or in Program.cs) provide the subsystem class instances.

    public double CalculateDiscountPercentage(int customerId)
    {
        if (!_orderService.HasEnoughOrders(customerId))
            return 0;

        return _customerDiscountBaseService.CalculateDiscountBase(customerId) * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
    }
}