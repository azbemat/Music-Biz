using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A6AZB.Models;

namespace W2022A6AZB.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        // Reference to the Manager
        private Manager m = new Manager();

        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.ArtistGetByIdWithMediaItemInfo(id.GetValueOrDefault());

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

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            // Create a form
            var form = new ArtistAddFormViewModel();

            // Configure the SelectList for the item-selection element on the HTML Form
            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");


            return View(form);
        }

        // POST: Artists/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }

        // Add album to known artist

        // GET: Artist/5/AddAlbum
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        public ActionResult AddAlbum(int id)
        {
            // Attempt to get the associated object
            var artist = m.ArtistGetById(id);

            if (artist == null)
            {
                return HttpNotFound();
            }
            else
            {

                // Create and configure a form object
                var formModel = new AlbumAddFormViewModel();

                formModel.ArtistId = artist.Id;
                formModel.ArtistName = artist.Name;

                IEnumerable<string> genres = m.GenreGetAll().Select(m => m.Name);

                formModel.GenreList = new SelectList(genres);

                return View(formModel);
            }
        }

        // POST: Artist/5/AddAlbum
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addalbum")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.AlbumAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", "albums", new { id = addedItem.Id });
            }
        }

        // Add Media item to known artist

        // GET: Artist/5/AddArtistMediaItem
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addartistmediaitem")]
        public ActionResult AddArtistMediaItem(int? id)
        {
            // Attempt to get the matching object
            var o = m.ArtistGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Create a form
                var form = new ArtistMediaItemAddFormViewModel();

                // Configure its artist values
                form.ArtistId = o.Id;
                form.ArtistInfo = o.Name;

                // Pass the object to the view
                return View(form);
            }
        }

        // POST: Artist/5/AddArtistMediaItem
        [Authorize(Roles = "Coordinator")]
        [Route("artist/{id}/addartistmediaitem")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddArtistMediaItem(int? id, ArtistMediaItemAddViewModel newItem)
        {
            // Validate the input
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }

            // Process the input
            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }
        }

    }
}
