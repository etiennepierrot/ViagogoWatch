using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Connector.Dto;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Subscriptions
{
    public class Subscription
    {
        public int NBPlace { get; private set; }
        public string Email { get; private set; }
        public Money MaxPricing { get; private set; }
        public List<Url> UrlSended { get; private set; }

        public string EventId { get; set; }

        public Subscription(Money maxPricing, int nbPlace, string email)
        {
            NBPlace = nbPlace;
            Email = email;
            MaxPricing = maxPricing;
            UrlSended = new List<Url>();
        }


        public IEnumerable<ProductDto> Match(IEnumerable<ProductDto> products)
        {
            return products.Where(Match);
        }

        private bool Match(ProductDto productDto)
        {
            return  new Money(productDto.RawPrice) <= MaxPricing 
                && productDto.AvailableQuantities.Contains(NBPlace) 
                &&  !UrlSended.Select(x=>x.ToString()).Contains(productDto.BuyUrl);
        }

        public void SetUrlSended(IEnumerable<Url> urlSended)
        {
            UrlSended.AddRange(urlSended);
        }
    }
}