using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1.Data
{
    [Table("Artist")]
    public class Artist
    {

        #region Constructor

        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        #endregion

        #region Columns

        public int ArtistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Album> Albums { get; set; }

        #endregion

    }
}
