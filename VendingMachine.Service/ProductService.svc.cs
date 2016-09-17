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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }

        public ICollection<ProductInventory> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public ProductInventory GetProduct(int productId)
        {
            return productRepository.GetProduct(productId);
        }

        public ProductInventory GetProductByTrayId(int trayId)
        {
            return productRepository.GetProductByTrayId(trayId);
        }

        public decimal GetProductSmallestPrice()
        {
            return productRepository.GetProductSmallestPrice();
        }

        public decimal GetProductPrice(int trayId)
        {
            return productRepository.GetProductPrice(trayId);
        }
    }
}
