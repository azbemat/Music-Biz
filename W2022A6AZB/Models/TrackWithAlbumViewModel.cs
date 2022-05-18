using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class TrackWithAlbumViewModel : TrackBaseViewModel
    {
        public TrackWithAlbumViewModel()
        {
            Albums = new List<AlbumBaseViewModel>();
        }

        [Display(Name = "Albums")]
        public IEnumerable<AlbumBaseViewModel> Albums { get; set; }

    }
}