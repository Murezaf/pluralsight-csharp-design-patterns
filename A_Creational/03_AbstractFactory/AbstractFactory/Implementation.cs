namespace AbstractFactory
{
    public class Implementation
    {
        public interface IDiscountService
        {
            int DiscountPercentage { get; }
        }

        public interface IShippingCostsService
        {
            decimal ShippingCosts { get; }
        }

        public interface IShoppingCartPurchaseFactory
        {
            IDiscountService CreateDiscountService();
            IShippingCostsService CreateShippingCostsService();
        }

        public class BelgiumDiscountService : IDiscountService
        {
            public int DiscountPercentage => 20;
        }

        public class FranceDiscountService : IDiscountService
        {
            public int DiscountPercentage => 10;
        }

        public class BelgiumShippingCostsService : IShippingCostsService
        {
            public decimal ShippingCosts => 20;
        }

        public class FranceShippingCostsService : IShippingCostsService
        {
            public decimal ShippingCosts => 25;
        }

        public class BelgiumShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
        {
            public IDiscountService CreateDiscountService()
            {
                return new BelgiumDiscountService();
            }

            public IShippingCostsService CreateShippingCostsService()
            {
                return new BelgiumShippingCostsService();
            }
        }

        public class FranceShoppingCartPurchaseFactory : IShoppingCartPurchaseFactory
        {
            public IDiscountService CreateDiscountService()
            {
                return new FranceDiscountService();
            }

            public IShippingCostsService CreateShippingCostsService()
            {
                return new FranceShippingCostsService();
            }
        }

        public class ShoppingCart
        {
            private readonly IDiscountService _discountService;
            private readonly IShippingCostsService _shippingCostsService;
            private int _orderCosts;

            public ShoppingCart(IShoppingCartPurchaseFactory shoppingCartPurchaseFactory)
            {
                _discountService = shoppingCartPurchaseFactory.CreateDiscountService();
                _shippingCostsService = shoppingCartPurchaseFactory.CreateShippingCostsService();

                _orderCosts = 200;
            }

            public void CalculateCosts()
            {
                Console.WriteLine($"Total costs: { _orderCosts - (_orderCosts * _discountService.DiscountPercentage / 100) + _shippingCostsService.ShippingCosts }");
            }
        }
    }
}