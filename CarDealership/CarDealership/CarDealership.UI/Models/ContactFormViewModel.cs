using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarDealership.Models.TabelModels
{
    public class ContactFormViewModel:IValidatableObject
    {
        public int? ContactId { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactMessage { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(ContactMessage))
            {
                errors.Add(new ValidationResult("Message Required"));
            }
            if (string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Email))
            {
                errors.Add(new ValidationResult("Must Enter Phone or Email"));
            }
            if (string.IsNullOrEmpty(ContactName))
            {
                errors.Add(new ValidationResult("Must enter Name"));
            }
            return errors;
        }
    }
}
