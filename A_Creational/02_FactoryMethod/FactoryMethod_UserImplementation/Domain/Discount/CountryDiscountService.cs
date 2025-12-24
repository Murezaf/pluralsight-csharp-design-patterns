namespace FactoryMethod2.Domain.Discount
{
    public class CountryDiscountService : DiscountService
    {
        private readonly string _country;

        public CountryDiscountService(string country)
        {
            _country = country;
        }

        public override int DiscountPercentage
        {
            get
            {
                return _country switch
                {
                    "Belgium" => 20,
                    _ => 10
                };
            }
        }
    }
}
