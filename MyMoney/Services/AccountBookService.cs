using MyMoney.Enum;
using MyMoney.Repositories;
using MyMoney.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyMoney.Services
{
    public class AccountBookService : IAccountBookService
    {
        private readonly IAccountBookRepository _AccountBookRepository;

        public AccountBookService()
        {
            _AccountBookRepository = new AccountBookRepository();
        }

        public IEnumerable<MoneyTxnViewModel> GetAllOrderByDate()
        {
            var accountBooks = _AccountBookRepository.GetAll();
            var moneyTxnViewModels = accountBooks.OrderBy(x => x.Dateee).Select(x => new MoneyTxnViewModel()
            {
                TxnType = (TxnType)x.Categoryyy,
                Date = x.Dateee,
                Amount = x.Amounttt
            });
            return moneyTxnViewModels;
        }
    }
}