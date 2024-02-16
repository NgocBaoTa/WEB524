using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a2.Data
{
    [Table("Album")]
    public class Album
    {

        #region Constructor

        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        #endregion

        #region Columns

        public int AlbumId { get; set; }

        [Required]
        [StringLength(160)]
        public string Title { get; set; }

        public int ArtistId { get; set; }


        #endregion

        #region Navigation Properties

        public Artist Artist { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Track> Tracks { get; set; }

        #endregion

    }
}
