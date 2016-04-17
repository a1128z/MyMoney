using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;
using MyMoney.Enum;

namespace MyMoney.ViewModels
{
    public class MoneyTxnViewModel
    {
        [Display(Name = "類別")]
        public TxnType TxnType { get; set; }
        [Display(Name = "金額")]
        public double Amount { get; set; }
        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        [Display(Name = "備註")]
        public string Remark { get; set; }
        
        public string GetTxnTypeName
        {
            get {
                switch (TxnType)
                {
                    case TxnType.Expenditure:
                        return "支出";
                    case TxnType.Income:
                        return "收入";
                    default:
                        return "";
                }
            }
        }
    }
}