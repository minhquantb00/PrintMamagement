﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<Bill>? Bills { get; set; }
        public virtual ICollection<Delivery>? Delivery { get; set; }
    }
}
