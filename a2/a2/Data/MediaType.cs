using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a2.Data
{
    [Table("MediaType")]
    public class MediaType
    {

        #region Constructor

        public MediaType()
        {
            Tracks = new HashSet<Track>();
        }

        #endregion

        #region Columns

        public int MediaTypeId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Track> Tracks { get; set; }

        #endregion

    }
}
