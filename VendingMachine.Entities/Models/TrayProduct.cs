using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Entity
{
    public partial class TrayProduct
    {
        public int Id { get; set; }
        public int TrayId { get; set; }
        public int ProductId { get; set; }        
    }
}
