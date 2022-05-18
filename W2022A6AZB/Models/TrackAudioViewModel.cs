using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6AZB.Controllers
{
    public class TrackAudioViewModel
    {
        public int Id { get; set; }
        public string AudioContentType { get; set; }
        public byte[] Audio { get; set; }

    }
}