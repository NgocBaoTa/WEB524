using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1.Data
{
    [Table("Customer")]
    public class Customer
    {

        #region Constructor

        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        #endregion

        #region Columns

        public int CustomerId { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

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

        [Required]
        [StringLength(60)]
        public string Email { get; set; }

        public int? SupportRepId { get; set; }

        #endregion

        #region Navigation Properties

        public Employee Employee { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<Invoice> Invoices { get; set; }

        #endregion

    }
}
