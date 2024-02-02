using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1.Data
{
    [Table("Track")]
    public class Track
    {

        #region Constructor

        public Track()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
            Playlists = new HashSet<Playlist>();
        }

        #endregion

        #region Columns

        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220)]
        public string Composer { get; set; }

        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        #endregion

        #region Navigation Properties

        public Album Album { get; set; }

        public Genre Genre { get; set; }

        public MediaType MediaType { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<InvoiceLine> InvoiceLines { get; set; }

        public ICollection<Playlist> Playlists { get; set; }

        #endregion

    }
}
