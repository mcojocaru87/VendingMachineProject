using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Entity
{
    public class ProductTray
    {
        public int Id { get; set; }
        public int TrayId { get; set; }
        public ProductInventory Product { get; set; }
    }
}
