using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendingMachine.Entity;
using VendingMachine.Service;

namespace VendingMachine.Web.Controllers
{
    public class MachineController : Controller
    {
        //
        // GET: /Machine/

        private readonly IInventoryService inventoryService;
        private readonly IProductService productService;
        private readonly ITrayService trayService;

        public MachineController(IInventoryService inventoryService,
            IProductService productService, ITrayService trayService)
        {
            this.inventoryService = inventoryService;
            this.productService = productService;
            this.trayService = trayService;
        }


        private const string DEFAULT_DISPLAY = "Have a nice day !";

        public ActionResult Index()
        {
            var trays = trayService.GetTray().ToList();


            var model = new Models.MachineViewModel
            {
                Trays = trays,
                Choices = Choices(trays.Count),
                Display = DEFAULT_DISPLAY
            };

            ViewBag.Model = model;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var displayMessage = string.Empty;

            var strTotal = collection["Total"] ?? 0.ToString();
            var total = int.Parse(strTotal);

            try
            {
                var strBills = collection["Bills"];
                var strCoins = collection["Coins"];
                var strChoice = collection["Choices"];


                var choice = int.Parse(strChoice);
                var errors = 0;


                var price = choice != 0 ? productService.GetProductPrice(choice) : productService.GetProductSmallestPrice();
                var machine = new Models.MachineModel(price, total);

                #region Check if user hit cancel
                if (string.IsNullOrWhiteSpace(strBills)
                    && string.IsNullOrWhiteSpace(strCoins)
                    && choice == 0
                    )
                {
                    machine = new Models.MachineModel(0, machine.Total);
                    displayMessage = machine.ReturnChange();
                    machine.Total = 0;
                }
                #endregion

                #region Validate if user has a choice but total has not been fully paid
                if (choice > 0)
                {
                    if (!machine.HasTotalBeenPaid())
                    {
                        errors++;
                        displayMessage = "Insufficient funds!";
                    }
                }

                #endregion

                #region Validate for real bills
                int bill = 0;
                if (!string.IsNullOrWhiteSpace(strBills))
                {

                    bool billPass = int.TryParse(strBills, out bill);

                    if (!billPass)
                    {
                        errors++;
                        displayMessage = "Invalid bill. Only bills allowed are: $5 and $10";
                    }
                    else
                        if (bill < 5)
                        {
                            errors++;
                            displayMessage = "Invalid bill. Only bills allowed are: $5 and $10";
                        }
                }
                #endregion

                #region Validate for real coins
                int coin = 0;
                if (!string.IsNullOrWhiteSpace(strCoins))
                {

                    bool coinPass = int.TryParse(strCoins, out coin);

                    if (!coinPass)
                    {
                        errors++;
                        displayMessage = "Invalid coin. Only coins allowed are: $1 and $2";
                    }
                    else
                        if (coin < 1)
                        {
                            errors++;
                            displayMessage = "Invalid bill. Only bills allowed are: $1 and $2";
                        }
                }
                #endregion

                if (errors == 0)
                {
                    if (!string.IsNullOrWhiteSpace(strBills) || !string.IsNullOrWhiteSpace(strCoins))
                    {
                        machine.DepositMoney(bill + coin);
                        displayMessage = string.Format("Your credit is: {0:c}", machine.Total);
                    }
                    else if (choice > 0)
                    {
                        if (!machine.HasTotalBeenPaid())
                        {
                            PopulateViewPageWithModel(displayMessage, machine.Total);
                            return View();
                        }
                        else
                        {
                            var product = productService.GetProductByTrayId(choice);
                            inventoryService.UpdateProductInventory(product.Id, product.Inventory.InStock - 1);
                            displayMessage = machine.ReturnChange();
                        }
                    }
                    else
                    {
                        PopulateViewPageWithModel(displayMessage, machine.Total);
                        return View();
                    }
                    total = machine.Total;
                }

            }
            catch (Exception ex)
            {

                displayMessage = ex.Message;
            }

            #region Repopulate View with Model
            PopulateViewPageWithModel(displayMessage, total);
            #endregion

            return View();
        }

        private void PopulateViewPageWithModel(string displayMessage, int total)
        {
            var trays = trayService.GetTray().ToList();

            var model = new Models.MachineViewModel
            {
                Trays = trays,
                Choices = Choices(trays.Count),
                Display = displayMessage,
                Total = total
            };

            ViewBag.Model = model;
        }

        private IEnumerable<SelectListItem> CreateChoices(int count)
        {
            List<SelectListItem> choices = new List<SelectListItem>();

            for (int i = 1; i < count + 1; i++)
            {
                choices.Add(new SelectListItem { Text = string.Format("T{0}", i), Value = i.ToString() });
            }

            return choices;
        }

        private List<SelectListItem> Choices(int trayCount)
        {
            var choices = new List<SelectListItem>();

            choices.Add(new SelectListItem { Selected = true, Text = "Please select", Value = 0.ToString() });
            choices.AddRange(CreateChoices(trayCount));

            return choices;
        }

    }
}
