using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VendingMachine.Entity;

namespace VendingMachine.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IInventoryService" in both code and config file together.
    [ServiceContract]
    public interface IInventoryService
    {
        [OperationContract]
        Inventory GetProductInventory(int productId);

        [OperationContract]
        void UpdateProductInventory(int productId, int stock);
    }
}
