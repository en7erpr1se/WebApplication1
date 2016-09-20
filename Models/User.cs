using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public ICollection<Job> Jobs { get; set; }
        public ICollection<Commentary> Commentaries { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public User()
        {
            Jobs = new List<Job>();
            Commentaries = new List<Commentary>();
            Feedbacks= new List<Feedback>();
        }

    }
}