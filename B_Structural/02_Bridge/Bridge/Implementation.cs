namespace Bridge;

//Implementor
public interface ICoupon
{
    int CouponValue {  get; }
}

//ConcreteImplementor
public class NoCoupon : ICoupon
{
    public int CouponValue { get { return 0; } }
}

//ConcreteImplementor
public class OneEuroCoupon : ICoupon
{
    public int CouponValue => 1;
}

//ConcreteImplementor
public class TwoEuroCoupon : ICoupon
{
    public int CouponValue => 2;
}

//Abstraction
public abstract class Menu
{
    public readonly ICoupon _coupon = null!;
    public abstract int CalculatePrice();

    public Menu(ICoupon coupon)
    {
        _coupon = coupon;
    }
}

//RefinedAbstraction
public class VegetarianMenu : Menu
{
    public VegetarianMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice()
    {
        return 20 - _coupon.CouponValue;
    }
}

//RefinedAbstraction
public class MeatBasedMenu : Menu
{
    public MeatBasedMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice()
    {
        return 30 - _coupon.CouponValue;
    }
}