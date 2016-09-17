using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VendingMachine.Entity;
using VendingMachine.Repository;

namespace VendingMachine.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InventoryService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select InventoryService.svc or InventoryService.svc.cs at the Solution Explorer and start debugging.
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository inventoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public InventoryService(IInventoryRepository inventoryRepository, IUnitOfWork unitOfWork)
        {
            this.inventoryRepository = inventoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public Inventory GetProductInventory(int productId)
        {
            return inventoryRepository.GetProductInventory(productId);
        }

        public void UpdateProductInventory(int productId, int stock)
        {
            inventoryRepository.UpdateProductInventory(productId, stock);
        }
    }
}
