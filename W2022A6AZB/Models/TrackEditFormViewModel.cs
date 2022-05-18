using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class TrackEditFormViewModel : TrackEditViewModel
    {

        // Display Purpose //
        [Required, StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        // Audio media type
        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }

    }
}