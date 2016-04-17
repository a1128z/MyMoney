﻿using MyMoney.Enum;
using MyMoney.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(MoneyTxnViewModel moneyTxnViewModel)
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var moneyTxnViewModels = new List<MoneyTxnViewModel>();
            for (int i = 0; i < 10; i++)
            {
                moneyTxnViewModels.Add(new MoneyTxnViewModel()
                {
                    TxnType = TxnType.Expenditure,
                    Amount = 23 * i,
                    Date = DateTime.Now.AddDays(-i),
                    Remark = "食物"
                });
            }
            for (int i = 0; i < 3; i++)
            {
                moneyTxnViewModels.Add(new MoneyTxnViewModel()
                {
                    TxnType = TxnType.Income,
                    Amount = 23 * 1,
                    Date = DateTime.Now.AddDays(-i * 12),
                    Remark = "營收"
                });
            }
            return View(moneyTxnViewModels.OrderBy(x => x.Date));
        }
    };
}