using MyMoney.Enum;
using MyMoney.Models;
using MyMoney.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class HomeController : Controller
    {
        private MoneyDb moneyDb = new MoneyDb();

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var moneyTxnViewModels = moneyDb.AccountBook.OrderBy(x => x.Dateee).Select(x => new MoneyTxnViewModel()
            {
                TxnType = (TxnType)x.Categoryyy,
                Date = x.Dateee,
                Amount = x.Amounttt,
                Remark = x.Remarkkk
            });
            return View(moneyTxnViewModels);
        }

        protected override void Dispose(bool disposing)
        {
            moneyDb.Dispose();
            base.Dispose(disposing);
        }
    };
}