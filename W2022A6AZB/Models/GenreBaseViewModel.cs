using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class GenreBaseViewModel
    {
        public int Id { get; set; }

        [StringLength(120)]
        [Display(Name = "Genre Name")]
        public string Name { get; set; }

    }
}