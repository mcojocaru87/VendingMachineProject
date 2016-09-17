using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Data;
using VendingMachine.Entity;

namespace VendingMachine.Repository
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(VendingMachineContext context)
            : base(context) { }

        public Inventory GetProductInventory(int productId)
        {
            return VendingMachineContext.Inventories.FirstOrDefault(i => i.ProductId == productId);
        }

        public void UpdateProductInventory(int productId, int stock)
        {
            var inventoryEntity = GetProductInventory(productId);

            if (inventoryEntity != null)
            {
                inventoryEntity.InStock = stock;
                VendingMachineContext.SaveChanges();
            }
        }
    }
}
