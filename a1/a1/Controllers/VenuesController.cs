using a1.Data;
using a1.Models;
using AutoMapper;
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

        // GET: venues
        public ActionResult Index()
        {
            return View(m.VenueGetAll());
        }

        // GET: venues/details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var obj = m.VenueGetById(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: venues/create
        public ActionResult Create()
        {
            return View();
        }

        // Post: venues/create
        [HttpPost]
        public ActionResult Create(VenueAddViewModel newItem)
        {
            if (!ModelState.IsValid) { 
                return View(newItem);
            }

            try
            {
                // Process the input
                var addedItem = m.VenueAdd(newItem);

                // If the item was not added, return the user to the Create page
                // otherwise redirect them to the Details page.
                if (addedItem == null)
                    return null; 
                else
                    return RedirectToAction("Details", new { id = addedItem.VenueId });
            }
            catch
            {
                return View(newItem);
            }
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int id)
        {
            // Fetch the existing venue data and map it to VenueEditFormViewModel
            var existingVenue = m.VenueGetById(id); // Fetch the venue based on the provided id

            if (existingVenue == null)
            {
                return HttpNotFound();
            } else
            {
                var viewModel = m.mapper.Map<VenueEditFormViewModel>(existingVenue);

                // Pass the view model to the view
                return View(viewModel);
            }
        }

        // POST: Venues/Edit/5
        [HttpPost]
        public ActionResult Edit(VenueEditViewModel item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                // Process the input
                var updatedItem = m.VenueEdit(item);

                if (updatedItem == null)
                     return null;
                else
                     return RedirectToAction("Details", new { id = updatedItem.VenueId });
            }
            catch
            {
                return View();
            }
        }
    }
}