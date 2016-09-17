using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Data;

namespace VendingMachine.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VendingMachineContext context;

        public UnitOfWork(VendingMachineContext context)
        {
            this.context = context;
            Inventories = new InventoryRepository(context);
        }

        public IInventoryRepository Inventories { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
