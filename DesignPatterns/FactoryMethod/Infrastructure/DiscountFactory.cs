using FactoryMethod.Domain;

namespace FactoryMethod.Infrastructure
{
    public abstract class DiscountFactory
    {
        public abstract DiscountService CreateDiscountService();
    }
}