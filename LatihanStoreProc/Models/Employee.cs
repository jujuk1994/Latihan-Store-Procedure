﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LatihanStoreProc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String Pin_Code { get; set; }
        public String Designation { get; set; }
    }
}