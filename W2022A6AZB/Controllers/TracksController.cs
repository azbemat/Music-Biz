using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6AZB.Models;

namespace W2022A6AZB.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {

        // Reference to the data manager
        private Manager m = new Manager();

        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAllWithDetail());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var track = m.TrackGetById(id.GetValueOrDefault());

            if (track == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(track);
            }
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            // Attempt to fetch the matching object
            var obj = m.TrackGetById(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();
            else
            {
                // Create and configure an "edit form"
                var formObj = m.mapper.Map<TrackBaseViewModel, TrackEditFormViewModel>(obj);
                return View(formObj);
            }
        }

        // POST: Tracks/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, TrackEditViewModel model)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", new { id = model.Id });
            }
            if (id.GetValueOrDefault() != model.Id)
            {
                // might be data tampering
                return RedirectToAction("Index");
            }

            // Attempt to do the update
            var editedItem = m.TrackEditInfo(model);
            if (editedItem == null)
            {
                // problem updating the object
                return RedirectToAction("Edit", new { id = model.Id });
            }
            else
            {
                // Show the details view, which will show the updated data
                return RedirectToAction("Details", new { id = model.Id });
            }
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                return RedirectToAction("Index");
            }
            else
                return View(itemToDelete);
        }

        // POST: Tracks/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());

            // Redirect to the list view
            return RedirectToAction("Index");
        }
    }
}
