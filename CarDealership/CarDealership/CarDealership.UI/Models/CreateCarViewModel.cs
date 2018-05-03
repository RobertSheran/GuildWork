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
    public class CreateCarViewModel:IValidatableObject
    {
        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<SelectListItem> BodyStyles { get; set; }
        public IEnumerable<SelectListItem> Transmissions { get; set; }
        public IEnumerable<SelectListItem> Interiors { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }
        public int CarId { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int TypeId { get; set; }
        public int BodyStyleId { get; set; }
        public int TransmissionId { get; set; }
        public int ColorId { get; set; }
        public int InteriorId { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public int Vin { get; set; }
        public int MSRP { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public string GottenPicture { get; internal set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            RepositoryManager repository = RepositoryManagerFactory.Create();

            List<ValidationResult> errors = new List<ValidationResult>();
            if (Year > (DateTime.Today.Year + 1) || Year < 2000)
            {
                errors.Add(new ValidationResult("Must have year between 2000 and " + (DateTime.Today.Year + 1)));
            }
            if (TypeId == 2)
            {
                if (Mileage > 1000)
                {
                    errors.Add(new ValidationResult("New Cars Cannot have more than 1000 miles"));
                }
            }

            if (TypeId == 1)
            {
                if (Mileage < 1000)
                {
                    errors.Add(new ValidationResult("Used Cars Cannot have less than 1000 miles"));
                }
            }

            if (MSRP <= 0||MSRP<Price)
            {
                errors.Add(new ValidationResult("MSRP is Required to be greater than sales price and must be positive"));
            }
            if (Price <= 0 || MSRP < Price)
            {
                errors.Add(new ValidationResult("Price is Required to be less than MSRP and must be positive"));
            }
            if (string.IsNullOrEmpty(Discription))
            {
                errors.Add(new ValidationResult("Discription is Required"));
            }
            return errors;
        }
    }
}