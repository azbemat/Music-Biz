using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Models
{
    public class ArtistMediaItemContentViewModel
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }

    }
}