using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A6AZB.Models
{
    public class AlbumAddFormViewModel : AlbumAddViewModel
    {

        // Display the name of the artist item
        public string ArtistName { get; set; }

        // Select List 
        [Display(Name = "Album's primary genre")]
        public SelectList GenreList { get; set; }

    }
}