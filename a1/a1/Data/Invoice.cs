using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1.Data
{
    [Table("Invoice")]
    public class Invoice
    {

        #region Constructor

        public Invoice()
        {
            InvoiceLines = new HashSet<InvoiceLine>();
        }

        #endregion

        #region Columns

        public int InvoiceId { get; set; }

        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }

        [StringLength(70)]
        public string BillingAddress { get; set; }

        [StringLength(40)]
        public string BillingCity { get; set; }

        [StringLength(40)]
        public string BillingState { get; set; }

        [StringLength(40)]
        public string BillingCountry { get; set; }

        [StringLength(10)]
        public string BillingPostalCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Total { get; set; }

        #endregion

        #region Navigation Properties

        public Customer Customer { get; set; }

        #endregion

        #region Entity Collections

        public ICollection<InvoiceLine> InvoiceLines { get; set; }

        #endregion

    }
}
