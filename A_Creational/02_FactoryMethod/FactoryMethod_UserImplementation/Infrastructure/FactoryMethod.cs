using Domain.User;
using FactoryMethod2.Domain.Discount;

namespace FactoryMethod2.Infrastructure
{
    public class DiscountFactory
    {
        public DiscountService CreateBest(User user)
        {
            return CreateAll(user)
                .OrderByDescending(d => d.DiscountPercentage)
                .First();
        }

        private IEnumerable<DiscountService> CreateAll(User user)
        {
            if (user.Country != null)
                yield return new CountryDiscountService(user.Country);

            if (user.DiscountCode.HasValue)
                yield return new CodeDiscountService(user.DiscountCode.Value);

            if (user.MembershipYears > 0)
                yield return new LoyaltyDiscountService(user.MembershipYears);
        }
    }
}