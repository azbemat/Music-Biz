using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6AZB.Controllers
{
    public class AudioController : Controller
    {
        // Reference to the manager object
        Manager m = new Manager();

        // GET: Audio
        public ActionResult Index()
        {
            return View("index", "home");
        }

        // GET: Audio/5
        [Route("clip/{id}")]

        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var o = m.TrackAudioGetById(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                // Set the Content-Type header, and return the photo bytes
                return File(o.Audio, o.AudioContentType);
            }
        }
  
    }
}
