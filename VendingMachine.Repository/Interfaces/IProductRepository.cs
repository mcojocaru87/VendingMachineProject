using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Entity;

namespace VendingMachine.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        ICollection<ProductInventory> GetAllProducts();

        ProductInventory GetProduct(int productId);

        ProductInventory GetProductByTrayId(int trayId);

        decimal GetProductSmallestPrice();

        decimal GetProductPrice(int trayId);
    }
}
