using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6AZB.Models;

namespace W2022A6AZB.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        // Reference to the Manager
        private Manager m = new Manager();

        // GET: Albums
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.AlbumGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Pass the object to the view
                return View(o);
            }
        }

        // GET: Album/{id}/Addtrack
        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        public ActionResult AddTrack(int id)
        {
            // Attempt to get the associated object
            var album = m.AlbumGetById(id);

            if (album == null)
            {
                return HttpNotFound();
            }
            else
            {

                // Create and configure a form object
                var formModel = new TrackAddFormViewModel();
                formModel.AlbumId = album.Id;
                formModel.AlbumName = album.Name;

                IEnumerable<string> genres = m.GenreGetAll().Select(m => m.Name);
                formModel.GenreList = new SelectList(genres);

                return View(formModel);
            }
        }

        // POST: Album/{id}/Addtrack
        [Authorize(Roles = "Clerk")]
        [Route("album/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAddViewModel newItem)
        {
            // Validate the input 
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.TrackAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "tracks", new { id = addedItem.Id });
            }
        }

        // -------------

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
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

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
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

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
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
