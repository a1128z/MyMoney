using System.Web.Mvc;
using MyMoney.Enum;

namespace MyMoney
{
    public static class MyHelp
    {
        public static string TxnColor(this HtmlHelper htmlHelper, TxnType txnType)
        {
            var output = string.Empty;
            switch (txnType)
            {
                case TxnType.Expenditure:
                    output = "text-danger";
                    break;
                case  TxnType.Income:
                    output = "text-primary";
                    break;
                default:
                    break;
            }
            return output;
        }
    }
}