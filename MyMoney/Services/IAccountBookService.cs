using System;
using System.Collections.Generic;
using MyMoney.ViewModels;

namespace MyMoney.Services
{
    public interface IAccountBookService
    {
        IEnumerable<MoneyTxnViewModel> GetAllOrderByDate();
        void Add(MoneyTxnViewModel moneyTxnViewModel);
        MoneyTxnViewModel GetSingle(Guid id);
        void Edit(MoneyTxnViewModel newData);
        void Delete(Guid id);
    }
}