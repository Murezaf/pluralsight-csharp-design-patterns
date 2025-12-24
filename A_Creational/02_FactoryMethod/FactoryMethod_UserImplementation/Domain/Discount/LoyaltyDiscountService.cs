namespace FactoryMethod2.Domain.Discount
{
    public class LoyaltyDiscountService : DiscountService
    {
        private readonly int _years;

        public LoyaltyDiscountService(int years)
        {
            _years = years;
        }

        public override int DiscountPercentage
        {
            get
            {
                return _years >= 5 ? 25 : 0;
            }
        }
    }
}
