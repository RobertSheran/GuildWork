using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class GroupedViewModel
    {
        public List<UserViewModel> Sellers { get; set; }
        public List<UserViewModel> Admins { get; set; }
    }
}