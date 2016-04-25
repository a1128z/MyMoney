using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMoney.Controllers
{
    public class ValidController : Controller
    {
        // GET: Valid
        public ActionResult TxnDate(DateTime date)
        {
            bool isValidate = date <= DateTime.Now;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}