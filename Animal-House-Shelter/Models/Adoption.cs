﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Animal_House_Shelter.Models
{
    public class Adoption
    {
        [BindNever]
        public int AdoptionID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "This is a required field.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "This is a required field.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "This is a required field.")]
        public string Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "This is a required field.")]
        public string City { get; set; }

        [Required]
        [StringLength(5000, ErrorMessage = "Your message is required"), Display(Name = "Tell me about You? Do You have pet? How big is Your house?")]
        public string Message { get; set; }

        public bool ContactMe { get; set; }

    }
}
