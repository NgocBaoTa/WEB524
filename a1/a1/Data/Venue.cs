using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace a1.Data
{
    [Table("Venue")]
    public class Venue
    {
        #region Columns

        public int VenueId { get; set; }

        [Required]
        [StringLength(80)]
        public string Company { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(60)]
        public string Website { get; set; }

        public DateTime? OpenDate { get; set; }

        #endregion

    }
}
