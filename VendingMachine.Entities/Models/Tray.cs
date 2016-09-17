using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Entity
{
    public partial class Tray
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }

        public Product Product { get; set; }
    }
}
