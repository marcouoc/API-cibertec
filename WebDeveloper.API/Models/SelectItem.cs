﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDeveloper.API.Models
{
    public class SelectItem
    {
        /*
         value= 0
         text=no promotion
         select=false*/

        public string Value { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }



    }
}