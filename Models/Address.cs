﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int ZipCode { get; set; }

        public ICollection<User> Users { get; set; }
        public Address()
        {
            Users = new List<User>();
        }
    }
}