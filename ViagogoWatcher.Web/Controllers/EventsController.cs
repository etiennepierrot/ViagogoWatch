using System.Web.Mvc;
using System.Web.Routing;
using ViagogoWatcher.Model.DependancyInjector;
using ViagogoWatcher.Model.Events;

namespace ViagogoWatcher.Web.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventsController()
        {
            _eventRepository = EventRepositoryBuilder.Build();
        }

        //
        // GET: /Events/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Events/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Events/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Events/Create
        [HttpPost]
        public ActionResult Create(string url, string name)
        {
            Event @event = new Event(url, name);
            _eventRepository.Add(@event);

            var urlSubscribe = Url.RouteUrl("Subscribe", new {codeEvent = @event.Code});

            var dto = new SuccessEventCrationDto
            {
                Url = urlSubscribe
            };

            return View("Success", dto);
        }


        //
        // GET: /Events/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Events/Edit/5
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
        // GET: /Events/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Events/Delete/5
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
