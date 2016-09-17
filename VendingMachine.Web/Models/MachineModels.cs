using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Entity;

namespace VendingMachine.Web.Models
{
    public class MachineViewModel
    {
        public List<ProductTray> Trays { get; set; }

        public string Display { get; set; }

        public string Bills { get; set; }

        public string Coins { get; set; }

        public List<SelectListItem> Choices { get; set; }

        public int Total { get; set; }
    }

    public class MachineModel
    {
        public int Total { get; set; }
        public decimal Price { get; set; }

        public MachineModel(decimal Price, int total)
        {
            Total = total;
            this.Price = Price;
        }

        public void DepositMoney(int money)
        {
            switch (money)
            {
                case 1:
                    Total += 1;
                    break;
                case 2:
                    Total += 2;
                    break;
                case 5:
                    Total += 5;
                    break;
                case 10:
                    Total += 10;
                    break;
                default:
                    throw new Exception("We only accept $1, $2 coins or $5, $10 bills");
            }
        }

        public bool HasTotalBeenPaid()
        {
            if (Total >= Price)
            {
                return true;
            }

            return false;
        }

        public string ReturnChange()
        {
            if (Total > Price)
            {
                return string.Format("Your change is: {0:c}", Total - Price);
            }

            return "Have a nice day!";
        }

    }
}