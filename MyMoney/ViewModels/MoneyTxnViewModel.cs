using MyMoney.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.ViewModels
{
    public class MoneyTxnViewModel
    {
        [Display(Name = "金額")]
        public double Amount { get; set; }

        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        public string Remark { get; set; }

        [Display(Name = "類別")]
        public TxnType TxnType { get; set; }
    }
}