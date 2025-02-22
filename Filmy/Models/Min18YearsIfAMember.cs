﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmy.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            int age = DateTime.Now.Year - customer.Birthdate.Year;

            return age >= 18 ? ValidationResult.Success : 
                               new ValidationResult("Customer should be at least 18 years old to be a member.");
        }
    }
}