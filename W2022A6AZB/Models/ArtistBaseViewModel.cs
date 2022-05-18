using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class ArtistBaseViewModel
    {

        public int Id { get; set; }

        // For an individual, can be birth name, or a stage/performer name
        // For a duo/band/group/orchestra, will typically be a stage/performer name
        [Required, StringLength(100)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        // For an individual, a birth name
        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        [Display(Name = "Birth date, or Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(512)]
        [Display(Name = "Artist photo")]
        public string UrlArtist { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }

        // User name who looks after this artist
        [Required, StringLength(200)]
        [Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; }

        [StringLength(2000)]
        [Display(Name = "Artist portrayal")]
        public string Portrayal { get; set; }

    }
}