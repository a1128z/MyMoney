﻿using MyMoney.Services;
using System.Web.Mvc;
using MyMoney.ViewModels;

namespace MyMoney.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountBookService _AccountBookService = new AccountBookService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "TxnType,Amount,Date,Remark")] MoneyTxnViewModel moneyTxnViewModel)
        {
            if (ModelState.IsValid)
            {
                _AccountBookService.Add(moneyTxnViewModel);
                return RedirectToAction("Index", "Home");
            }
            return View(moneyTxnViewModel);
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var moneyTxnViewModels = _AccountBookService.GetAllOrderByDate();
            return View(moneyTxnViewModels);
        }

        [HttpPost]
        public ActionResult IndexForAjax(MoneyTxnViewModel moneyTxnViewModel)
        {
            if (ModelState.IsValid)
            {
                _AccountBookService.Add(moneyTxnViewModel);
                return PartialView("List",_AccountBookService.GetAllOrderByDate());
            }
            return View("Index",moneyTxnViewModel);
        }
    };
}