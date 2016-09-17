using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VendingMachine.Entity;

namespace VendingMachine.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        ICollection<ProductInventory> GetAllProducts();

        [OperationContract]
        ProductInventory GetProduct(int productId);

        [OperationContract]
        ProductInventory GetProductByTrayId(int trayId);

        [OperationContract]
        decimal GetProductSmallestPrice();

        [OperationContract]
        decimal GetProductPrice(int trayId);
    }
}
