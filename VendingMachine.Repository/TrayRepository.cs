using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Data;
using VendingMachine.Entity;

namespace VendingMachine.Repository
{
    public class TrayRepository : Repository<Tray>, ITrayRepository
    {
        public TrayRepository(VendingMachineContext context)
            : base(context) { }

        public ICollection<ProductTray> GetTray(int trayId = 0)
        {
            IQueryable<ProductTray> qObj;

            qObj = (from tp in VendingMachineContext.TrayProducts
                    join t in VendingMachineContext.Trays on tp.TrayId equals t.Id
                    join p in VendingMachineContext.Products on tp.ProductId equals p.Id
                    join i in VendingMachineContext.Inventories on p.Id equals i.ProductId
                    select new ProductTray
                    {
                        Id = tp.Id,
                        TrayId = t.Id,
                        Product = new ProductInventory { Id = p.Id, Name = p.Name, Price = p.Price, Inventory = i }
                    });

            if (trayId > 0)
            {
                qObj = qObj.Where(x => x.TrayId == trayId);
            }

            return qObj.ToList();

        }

    }
}
