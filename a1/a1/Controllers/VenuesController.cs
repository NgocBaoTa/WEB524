using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a1.Controllers
{
    public class VenuesController : Controller
    {
        private Manager m = new Manager();

        // GET: Venues
        public ActionResult Index()
        {
            return View(m.VenueGetAll());
        }
    }
}