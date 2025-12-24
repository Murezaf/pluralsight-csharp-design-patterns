namespace FactoryMethod.Domain
{
    public class CodeDiscountService : DiscountService
    {
        private readonly Guid _code;

        public CodeDiscountService(Guid code)
        {
            _code = code;
        }

        public override int DiscountPersentage
        {
            //Every code is valid once, so a check is needed for this purpose

            //get { return 15; }
            get => 15;
        }
    }
}
