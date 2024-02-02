using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1.Data
{
    [Table("Genre")]
    public class Genre
    {

        #region Constructor

        public Genre()
        {
            Tracks = new HashSet<Track>();
        }

        #endregion

        #region Columns

        public int GenreId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Track> Tracks { get; set; }

        #endregion

    }
}
