﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentExample.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
    }
}