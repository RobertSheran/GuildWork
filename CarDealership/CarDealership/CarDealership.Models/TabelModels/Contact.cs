using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.TabelModels
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactMessage { get; set; }
    }
}
