using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Repository.Models.Domain
{
    public class BuyerForm
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName {  get; set; }

        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email {  get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits.")]
        [Display(Name = "Phone number")]
        public string Phone {  get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}
