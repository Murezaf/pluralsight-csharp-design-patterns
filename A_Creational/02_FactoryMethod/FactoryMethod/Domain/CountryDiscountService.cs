namespace FactoryMethod.Domain
{
    public class CountryDiscountService : DiscountService
    {
        private readonly string _discountIdentifier;

        public CountryDiscountService(string discountIdentifier)
        {
            _discountIdentifier = discountIdentifier;
        }

        public override int DiscountPersentage
        {
            get
            {
                switch(_discountIdentifier)
                {
                    case "Belgium":
                        return 20;
                    default: 
                        return 10;
                }
            }
        }
    }
}