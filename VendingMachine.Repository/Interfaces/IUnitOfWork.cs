using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingMachine.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
