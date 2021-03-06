﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Score { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? JobId { get; set; }
        public Job Job { get; set; }
    }
}