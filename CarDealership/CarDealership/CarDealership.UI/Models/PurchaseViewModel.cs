using CarDealership.BLL.Factories;
using CarDealership.BLL.Managers;
using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseViewModel: Invoice,IValidatableObject
    {
        public DetailedCarViewModel Car { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }

        public int CarId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            RepositoryManager repositoryManager = RepositoryManagerFactory.Create();
            Cars car = repositoryManager.GetCars(CarId).Cars;

            List<ValidationResult> errors = new List<ValidationResult>();
            if (Price < (car.SalesPrice * 95) / 100)
            {
                errors.Add(new ValidationResult("Price must be > 95% of SalesPrice. That is, > "+ (car.SalesPrice * 95) / 100));
            }

            if (Price > car.MSRP)
            {
                errors.Add(new ValidationResult("Price must be < MSRP "+ repositoryManager.GetCars(CarId).Cars.MSRP));
            }
            

            if ((string.IsNullOrEmpty(Phone) && string.IsNullOrEmpty(Email))||Email.All(c=>c!='@'))
            {
                errors.Add(new ValidationResult("Must Enter Phone or valid Email"));
            }

            if (string.IsNullOrEmpty(InvoiceState))
            {
                errors.Add(new ValidationResult("Must Select state"));
            }
            if (string.IsNullOrEmpty(City))
            {
                errors.Add(new ValidationResult("Must enter city"));
            }
            if (string.IsNullOrEmpty(StreetOne))
            {
                errors.Add(new ValidationResult("Must Enter StreetOne"));               
            }
            if (ZipCode==null||ZipCode.Count() != 5)
            {
                errors.Add(new ValidationResult("Zip Must be 5 digits"));
            }

            if (!int.TryParse(ZipCode,out int x))
            {
                errors.Add(new ValidationResult("Zip must be numbers"));
            }
            
            if (string.IsNullOrEmpty(PerchaseType))
            {
                errors.Add(new ValidationResult("Must Have PerchaseType"));              
            }

            if (string.IsNullOrEmpty(InvoiceName))
            {
                errors.Add(new ValidationResult("InvoiceName Must be given a value"));
            }

            return errors;
        }
    }
}