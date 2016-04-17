using MyMoney.Services;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountBookService _AccountBookService = new AccountBookService();

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var moneyTxnViewModels = _AccountBookService.GetAllOrderByDate();
            return View(moneyTxnViewModels);
        }
    };
}