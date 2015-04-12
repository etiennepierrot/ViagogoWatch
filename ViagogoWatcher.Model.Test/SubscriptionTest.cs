using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ViagogoWatcher.Model.Connector.Dto;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Subscriptions;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Test
{
    [TestFixture]
    public class SubscriptionTest
    {
        private Subscription subscription;

        [SetUp]
        public void Setup()
        {
            subscription = new Subscription(new Money(50), 2, "etienne.pierrot@gmail.com", "123");
            
        }


        [Test]
        public void Match_Should_Return_Product()
        {
            IEnumerable<ProductDto> products = GetProducts(2, new Money(20));


            IEnumerable<ProductDto> productsMatching = subscription.Match(products);

            Assert.That(productsMatching.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Match_Should_Not_Return_Product_If_Price_Is_Too_High()
        {
            IEnumerable<ProductDto> products = GetProducts(2, new Money(60));

            IEnumerable<ProductDto> productsMatching = subscription.Match(products);

            Assert.That(productsMatching.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Match_Should_Not_Return_Product_If_Not_Enough_Places()
        {
            IEnumerable<ProductDto> products = GetProducts(1, new Money(20));

            IEnumerable<ProductDto> productsMatching = subscription.Match(products);

            Assert.That(productsMatching.Count(), Is.EqualTo(0));
        }

        [Test]
        public void Match_Should_Return_Url_Already_Send()
        {
            IEnumerable<ProductDto> products = GetProducts(2, new Money(20));
            subscription.SetUrlSended(products.Select(x => new Url(x.BuyUrl)));

            IEnumerable<ProductDto> productsMatching = subscription.Match(products);


            Assert.That(productsMatching.Count(), Is.EqualTo(0));

        }

        private static List<ProductDto> GetProducts(int availableQuantitie, Money rawPrice)
        {
            return new List<ProductDto>
            {
                new ProductDto
                {
                    AvailableQuantities = new List<long> {availableQuantitie},
                    RawPrice = rawPrice.Amount,
                    BuyUrl = "http://buyurl.com",
                    Section = "Section A",
                    TicketClassName = "7"
                }
            };
        }
    }

}