using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.TabelModels
{
    public class Cars
    {
        public int CarId { get; set; }
        public int Vin { get; set; }
        public int SalesPrice { get; set; }
        public int MSRP { get; set; }
        public int CarYear { get; set; }
        public string AspNetUserId { get; set; }
        public int InteriorColorId { get; set; }
        public int TransmissionId { get; set; }
        public int CarTypeId { get; set; }
        public int ColorId { get; set; }
        public int Mileage { get; set; }
        public int BodyStyleId { get; set; }
        public int CarModelId { get; set; }
        public bool Special { get; set; }
        public string Photo { get; set; }
        public string Discription { get; set; }
        public bool Sold { get; set; }
    }
}
