using System;
using System.Net;
using System.Web.Mvc;
using AuthSample.Filter;
using MyMoney.Services;
using MyMoney.ViewModels;

namespace MyMoney.Areas.Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountBookService _AccountBookService = new AccountBookService();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [ValidateAntiForgeryToken]
        public ActionResult IndexForAjax(MoneyTxnViewModel moneyTxnViewModel)
        {
            if (ModelState.IsValid)
            {
                _AccountBookService.Add(moneyTxnViewModel);
                return PartialView("List",_AccountBookService.GetAllOrderByDate());
            }
            return View("Index",moneyTxnViewModel);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moneyTxnViewModel = _AccountBookService.GetSingle(id.Value);
            if (moneyTxnViewModel == null)
            {
                return HttpNotFound();
            }
            return View(moneyTxnViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TxnType,Amount,Date,Remark")] MoneyTxnViewModel moneyTxnViewModel)
        {
            if (moneyTxnViewModel == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var oldData = _AccountBookService.GetSingle(moneyTxnViewModel.Id);
            if (oldData != null && ModelState.IsValid)
            {
                _AccountBookService.Edit(moneyTxnViewModel);
                return RedirectToAction("Index");
            }
            return View(moneyTxnViewModel);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moneyTxnViewModel = _AccountBookService.GetSingle(id.Value);
            if (moneyTxnViewModel == null)
            {
                return HttpNotFound();
            }
            return View(moneyTxnViewModel);
        }
        
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var moneyTxnViewModel = _AccountBookService.GetSingle(id.Value);
            if (moneyTxnViewModel == null)
            {
                return HttpNotFound();
            }
            return View(moneyTxnViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            _AccountBookService.Delete(id);
            return RedirectToAction("Index");

        }
    };
}