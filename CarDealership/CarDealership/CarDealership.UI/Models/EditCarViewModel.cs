using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class EditCarViewModel:CreateCarViewModel,IValidatableObject
    {
        public bool Sold { get; set; }
        public bool Special { get; set; }
    }
}