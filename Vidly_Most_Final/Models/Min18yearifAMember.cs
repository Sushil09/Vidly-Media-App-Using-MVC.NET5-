using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly_Most_Final.Models
{
    public class Min18yearifAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ?
                   ValidationResult.Success :
                   new ValidationResult("Customer should be atleast 18 years or more");
        }
    }
}