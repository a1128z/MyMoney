using System;
using System.Collections.Generic;
using MyMoney.ViewModels;

namespace MyMoney.Services
{
    public interface IAccountBookService : IDisposable
    {
        IEnumerable<MoneyTxnViewModel> GetAllOrderByDate();
    }
}