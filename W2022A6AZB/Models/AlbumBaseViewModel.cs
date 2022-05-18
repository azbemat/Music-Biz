using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class AlbumBaseViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Album name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        [Display(Name = "Album image (cover art)")]
        public string UrlAlbum { get; set; }

        [Required]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }

        // User name who looks after the album
        [Required, StringLength(200)]
        [Display(Name = "Coordinator who looks after the album")]
        public string Coordinator { get; set; }

        [StringLength(2000)]
        [Display(Name = "Album Background")]
        public string Background { get; set; }

    }
}