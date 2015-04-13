using System;
using System.Collections.Generic;
using System.Linq;
using ViagogoWatcher.Model.Connector.Dto;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Persistances;
using ViagogoWatcher.Model.Urls;

namespace ViagogoWatcher.Model.Subscriptions
{
    public class Subscription
    {
        public int NBPlace
        {
            get { return State.NBPlace; }
        }

        public string CodeSubscription
        {
            get { return State.CodeSubscription; }
        }

        public string Email
        {
            get { return State.Email; }
        }

        public Money MaxPricing
        {
            get
            {
                return new Money(State.MaxPricing);
            }
        }

        public List<Url> UrlSended
        {
            get { return State.UrlStates.Select(x => new Url(x.Url)).ToList(); }
        }

        public string CodeEvent
        {
            get { return State.CodeEvent; }
        }

        internal SubscriptionState State;

        public Subscription(Money maxPricing, int nbPlace, string email, string codeEvent)
        {
            State = new SubscriptionState();
            State.NBPlace = nbPlace;
            State.Email = email;
            State.CodeEvent = codeEvent;
            State.MaxPricing = maxPricing.Amount;
            State.CodeSubscription = Guid.NewGuid().ToString("N").Substring(0, 6);
            State.UrlStates = new List<UrlState>();
        }

        internal Subscription(SubscriptionState subscriptionState)
        {
            State = subscriptionState;
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
            foreach (var url in urlSended)
            {
                State.UrlStates.Add(new UrlState()
                {
                    Url = url.ToString()
                });
            }
        }
    }
}