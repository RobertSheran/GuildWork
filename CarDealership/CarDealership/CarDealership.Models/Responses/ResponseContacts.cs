﻿using CarDealership.Models.TabelModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealership.Models.Responses
{
    public class ResponseContacts:Response
    {
        public List<Contact> Contacts { get; set; }
    }
}
