using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class TrackEditViewModel
    {

        public int Id { get; set; }

        // Audio media type
        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }

    }
}