using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubcribedToNewsletter { get; set; }

        [Required]
        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime Birthdate { get; set; }
        public List<Movie> MovieLibrary { get; set; }
    }
}