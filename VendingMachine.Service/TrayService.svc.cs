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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TrayService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TrayService.svc or TrayService.svc.cs at the Solution Explorer and start debugging.
    public class TrayService : ITrayService
    {
        private readonly ITrayRepository trayRepository;
        private readonly IUnitOfWork unitOfWork;

        public TrayService(ITrayRepository trayRepository, IUnitOfWork unitOfWork)
        {
            this.trayRepository = trayRepository;
            this.unitOfWork = unitOfWork;
        }
        public ICollection<ProductTray> GetTray(int trayId = 0)
        {
            return trayRepository.GetTray(trayId);
        }
    }
}
