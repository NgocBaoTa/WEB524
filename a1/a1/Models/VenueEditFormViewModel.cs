using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace a1.Models
{
    public class VenueEditBaseViewModel
    {
        [Display(Name = "Venue ID")]
        public int VenueId { get; set; }

        [Display(Name = "Company Name")]
        public string Company { get; set; }

        [Required, StringLength(100)]
        public string Address { get; set; }

        [Required, StringLength(15)]
        public string City { get; set; }

        [Required, StringLength(15)]
        public string State { get; set; }

        [Required, StringLength(20)]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$", ErrorMessage = "Postal Code must be in the format: LNL NLN, e.g.: M9W 1T6")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required, StringLength(12, MinimumLength = 9)]
        public string Phone { get; set; }

        [Required, StringLength(10)]
        public string Fax { get; set; }

        [Required, StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, StringLength(100)]
        [DataType(DataType.Url)]
        public string Website { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpenDate { get; set; }
    }
    public class VenueEditFormViewModel : VenueEditBaseViewModel
    {
        [StringLength(30)]
        [DataType(DataType.Password)]
        [Display(Name = "Advanced Ticket Sale Password")]
        public string TicketSalePassword { get; set; }

        [RegularExpression("^[0-9]{2}[A-Z]{3}$", ErrorMessage = "Promo Code must be in the format 'NNLLL', e.g., '12XYZ'")]
        [Display(Name = "Promo Code")]
        public string PromoCode { get; set; }

        [Range(1, 75000, ErrorMessage = "Capacity must be between 1 and 75,000")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }
    }
}