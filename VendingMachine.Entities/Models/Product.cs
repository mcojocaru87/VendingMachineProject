﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Entity
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
