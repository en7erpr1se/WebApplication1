using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Job
    {
        public int Id { get; set; }
        public DateTime JobDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public ICollection<Commentary> Commentaries { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public Job()
        {
            Commentaries = new List<Commentary>();
            Feedbacks = new List<Feedback>();
        }
    }
}