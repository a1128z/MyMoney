using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyMoney.Enum
{
    public enum TxnType
    {
        [Display(Name = "支出")]
        Expenditure = 1,

        [Display(Name = "收入")]
        Income = 2
    }
}