using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectOnlineShop.Data.Entities
{
    public class Customer
    {
        [Required]
        public Guid Id { get; set; }
        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Email address")]
        [UIHint("EmailAddress")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Country")]
        [Required]
        public string Country { get; set; }
        [Display(Name = "Adress")]
        [Required]
        public string Address { get; set; }
        [Display(Name = "Town")]
        [Required]
        public string Town { get; set; }
        [Display(Name = "Zipcode")]
        [Required]
        public string ZipCode { get; set; }
        [Display(Name = "Phone number")]
        [UIHint("PhoneNumber")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Comment")]
        public string OrderComment { get; set; }
        public Order Order { get; set; }
        public Guid OrderId { get; set; }
    }
}
