namespace FactoryMethod.Domain
{
    public abstract class DiscountService
    {
        public abstract int DiscountPersentage { get; }

        public override string ToString() => GetType().Name;
    }
}