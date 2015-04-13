using System;
using System.Web;
using System.Web.Mvc;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Events;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Subscriptions;

namespace ViagogoWatcher.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IEventRepository _eventRepository;

        public SubscriptionsController()
        {
            _subscriptionRepository =  SubscriptionRepositoryBuilder.Build();
            _eventRepository = EventRepositoryBuilder.Build();
        }

        //
        // GET: /Subscriptions/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Subscriptions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Subscriptions/Create
        public ActionResult Create(string codeEvent)
        {
            Event @event = _eventRepository.FindByCode(codeEvent);

            if (@event == Event.NotFound)
            {
                throw new HttpException(404, "event not found");
            }

            DisplayCreateSubscriptionDto displayCreateSubscriptionDto = new DisplayCreateSubscriptionDto
            {
                CodeEvent = codeEvent,
                NameEvent = @event.Name   
            };

            return View(displayCreateSubscriptionDto);
        }

        //
        // POST: /Subscriptions/Create
        [HttpPost]
        public ActionResult Create(string codeEvent, string email, string amount, string quantity)
        {
            try
            {
                int intAmount = int.Parse(amount);
                int intNbPlace = int.Parse(quantity);
                Subscription subscription = new Subscription(new Money(intAmount), intNbPlace, email, codeEvent);
                _subscriptionRepository.Add(subscription);

                return View("Success");
            }
            catch(Exception e)
            {
                return View();
            }
        }



        [HttpGet]
        public ActionResult UnSubscribe(string codeSubscription)
        {
            _subscriptionRepository.DeleteByCode(codeSubscription);
            return View("Unsubcribe");
        }

        //
        // POST: /Subscriptions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Subscriptions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Subscriptions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
