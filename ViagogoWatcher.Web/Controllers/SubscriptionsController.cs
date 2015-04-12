using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Moneys;
using ViagogoWatcher.Model.Subscriptions;

namespace ViagogoWatcher.Web.Controllers
{
    public class SubscriptionsController : Controller
    {
        private ISubscriptionRepository _subscriptionRepository;

        public SubscriptionsController()
        {
            _subscriptionRepository =  SubscriptionRepositoryBuilder.Build();
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
            DisplayCreateSubscriptionDto displayCreateSubscriptionDto = new DisplayCreateSubscriptionDto
            {
                codeEvent = codeEvent
            };
            return View(displayCreateSubscriptionDto);
        }

        //
        // POST: /Subscriptions/Create
        [HttpPost]
        public ActionResult Create(string codeEvent, string email, string amount, string nbPlace)
        {
            try
            {
                int intAmount = int.Parse(amount);
                int intNbPlace = int.Parse(nbPlace);
                Subscription subscription = new Subscription(new Money(intAmount), intNbPlace, email, codeEvent);
                _subscriptionRepository.Add(subscription);

                return Create(codeEvent);
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Subscriptions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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

    public class DisplayCreateSubscriptionDto
    {
        public string codeEvent { get; set; }
    }
}
