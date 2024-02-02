using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1.Data
{
    [Table("Playlist")]
    public class Playlist
    {

        #region Constructor

        public Playlist()
        {
            Tracks = new HashSet<Track>();
        }

        #endregion

        #region Columns

        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Track> Tracks { get; set; }

        #endregion

    }
}
