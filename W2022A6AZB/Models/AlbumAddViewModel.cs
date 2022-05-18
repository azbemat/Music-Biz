using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class AlbumAddViewModel
    {

        public AlbumAddViewModel()
        {
            ReleaseDate = DateTime.Now.AddYears(-22);
        }

        [Display(Name = "Album name")]
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        [Display(Name = "URL to album image (cover art)")]
        public string UrlAlbum { get; set; }

        [Required]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }

        // Identifier for the associated item 
        [Range(1, Int32.MaxValue)]
        public int ArtistId { get; set; }

        [StringLength(2000)]
        [Display(Name = "Album Background")]
        [DataType(DataType.MultilineText)]
        public string Background { get; set; }

    }
}