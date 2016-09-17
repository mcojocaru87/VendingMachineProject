using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VendingMachine.Entity;

namespace VendingMachine.Repository
{
    public interface ITrayRepository : IRepository<Tray>
    {
        ICollection<ProductTray> GetTray(int trayId = 0);
    }
}
