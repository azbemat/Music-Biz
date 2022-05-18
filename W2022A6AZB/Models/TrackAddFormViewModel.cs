using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6AZB.Models
{
    public class TrackAddFormViewModel : TrackAddViewModel
    {

        // SelectList for genres
        [Display(Name = "Track genre")]
        public SelectList GenreList { get; set; }

        // Display associated item
        public string AlbumName { get; set; }

        // Audio media type
        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }
}