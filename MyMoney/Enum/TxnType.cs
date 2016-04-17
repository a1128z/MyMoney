using System.ComponentModel.DataAnnotations;

namespace MyMoney.Enum
{
    public enum TxnType
    {
        [Display(Name = "支出")]
        Expenditure = 0,

        [Display(Name = "收入")]
        Income = 1
    }
}