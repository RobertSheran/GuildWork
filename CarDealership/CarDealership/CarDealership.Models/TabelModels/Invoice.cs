using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.TabelModels
{
    public class Invoice
    {
        public string PerchaseType { get; set; }
        public int Price { get; set; }
        public string ZipCode { get; set; }
        public string InvoiceState { get; set; }
        public string City { get; set; }
        public string StreetTwo { get; set; }
        public string StreetOne { get; set; }
        public string Email { get; set; }
        public string InvoiceName { get; set; }
        public string Phone { get; set; }
        public int? InvoiceId { get; set; }
    }
}
