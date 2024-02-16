using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace a2.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }
    }
}