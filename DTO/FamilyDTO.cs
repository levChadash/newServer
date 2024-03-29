﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class FamilyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Neighborhood { get; set; }
        public string VolunteerType { get; set; }
        public int VolunteerTypeId { get; set; }
        public bool Approved { get; set; }
        public bool Challenging { get; set; }
        public bool Active { get; set; }
        public bool OneTime { get; set; }

    }
}
