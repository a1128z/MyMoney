using MyMoney.Enum;
using MyMoney.Models;
using MyMoney.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyMoney.Services
{
    public class AccountBookService : IAccountBookService
    {
        private readonly MoneyDb _MoneyDb;

        public AccountBookService()
        {
            _MoneyDb = new MoneyDb();
        }

        public void Dispose()
        {
            _MoneyDb.Dispose();
        }

        public IEnumerable<MoneyTxnViewModel> GetAllOrderByDate()
        {
            var moneyTxnViewModels = _MoneyDb.AccountBook.OrderBy(x => x.Dateee).Select(x => new MoneyTxnViewModel()
            {
                TxnType = (TxnType)x.Categoryyy,
                Date = x.Dateee,
                Amount = x.Amounttt,
                Remark = x.Remarkkk
            });
            return moneyTxnViewModels;
        }
    }
}