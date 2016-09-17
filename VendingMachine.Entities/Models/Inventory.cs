using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Entity
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InStock { get; set; }
    }
}
