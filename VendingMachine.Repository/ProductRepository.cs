using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Entity;

namespace VendingMachine.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(VendingMachineContext context)
            : base(context) { }

        public ICollection<ProductInventory> GetAllProducts()
        {
            return (from p in VendingMachineContext.Products
                    join i in VendingMachineContext.Inventories on p.Id equals i.ProductId
                    select new ProductInventory { Id = p.Id, Inventory = i, Name = p.Name }).ToList();
        }

        public ProductInventory GetProduct(int productId)
        {
            return (from p in VendingMachineContext.Products
                    join i in VendingMachineContext.Inventories on p.Id equals i.ProductId
                    select new ProductInventory
                    {
                        Id = p.Id,
                        Inventory = i,
                        Name = p.Name
                    }).SingleOrDefault(x => x.Id == productId);
        }

        public ProductInventory GetProductByTrayId(int trayId)
        {
            return (from tp in VendingMachineContext.TrayProducts
                    join p in VendingMachineContext.Products on tp.ProductId equals p.Id
                    join i in VendingMachineContext.Inventories on p.Id equals i.ProductId
                    where tp.TrayId == trayId
                    select new ProductInventory { Id = p.Id, Inventory = i, Name = p.Name, Price = p.Price }).SingleOrDefault();
        }

        public decimal GetProductSmallestPrice()
        {
            return VendingMachineContext.Products
                .OrderBy(x => x.Price)
                .Select(x => x.Price)
                .Take(1)
                .Distinct()
                .FirstOrDefault();
        }

        public decimal GetProductPrice(int trayId)
        {
            return (from tp in VendingMachineContext.TrayProducts
                    join p in VendingMachineContext.Products on tp.ProductId equals p.Id
                    where tp.TrayId == trayId
                    select p.Price).FirstOrDefault();
        }

    }
}
