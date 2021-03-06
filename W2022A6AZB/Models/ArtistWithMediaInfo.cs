using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class ArtistWithMediaInfo : ArtistBaseViewModel
    {
        public ArtistWithMediaInfo()
        {
            ArtistMediaItems = new List<ArtistMediaItemBaseViewModel>();
        }

        public IEnumerable<ArtistMediaItemBaseViewModel> ArtistMediaItems { get; set; }

    }
}