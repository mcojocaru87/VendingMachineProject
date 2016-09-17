using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Entity;

namespace VendingMachine.Repository
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Inventory GetProductInventory(int productId);

        void UpdateProductInventory(int productId, int stock);

    }
}
