using MyMoney.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyMoney.Filters;

namespace MyMoney.ViewModels
{
    public class MoneyTxnViewModel
    {
        [Required(ErrorMessage = "請選擇{0}")]
        [Display(Name = "類別")]
        public TxnType TxnType { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} 輸入錯誤，請輸入大於0的正整數。")]
        [Display(Name = "金額")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "請輸入{0}")]
        [RemotePlus("TxnDate", "Valid", "", ErrorMessage = "請輸入今天以前日期。")]
        [Display(Name = "日期")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        [StringLength(100, ErrorMessage = "超過100個字了!")]
        public string Remark { get; set; }

    }
}