using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace a1.Models
{
    public class VenueAddViewModel
    {
        [Required]
        [StringLength(80)]
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
        public DateTime? OpenDate { get; set; }

        public VenueAddViewModel() { 
            OpenDate = DateTime.Now.AddYears(-23);
        }

    }
}