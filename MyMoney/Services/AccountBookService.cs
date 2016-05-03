using System;
using MyMoney.Enum;
using MyMoney.Repositories;
using MyMoney.ViewModels;
using System.Collections.Generic;
using System.Linq;
using MyMoney.Models;

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
                Id = x.Id,
                TxnType = (TxnType)x.Categoryyy,
                Date = x.Dateee,
                Amount = x.Amounttt
            });
            return moneyTxnViewModels;
        }

        public void Add(MoneyTxnViewModel moneyTxnViewModel)
        {
            var accountBook = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = moneyTxnViewModel.Amount,
                Categoryyy = (int)moneyTxnViewModel.TxnType,
                Dateee = moneyTxnViewModel.Date,
                Remarkkk = moneyTxnViewModel.Remark
            };
            _AccountBookRepository.Add(accountBook);
        }

        public MoneyTxnViewModel GetSingle(Guid id)
        {
            var accountBook = _AccountBookRepository.GetSingle(id);
            return new MoneyTxnViewModel()
            {
                Amount = accountBook.Amounttt,
                Date = accountBook.Dateee,
                Id = accountBook.Id,
                Remark = accountBook.Remarkkk,
                TxnType = (TxnType)accountBook.Categoryyy
            };
        }

        public void Edit(MoneyTxnViewModel newData)
        {
            var accountBook = new AccountBook()
            {
                Id = newData.Id,
                Amounttt = newData.Amount,
                Categoryyy = (int)newData.TxnType,
                Dateee = newData.Date,
                Remarkkk = newData.Remark
            };
            _AccountBookRepository.Edit(accountBook);

        }

        public void Delete(Guid id)
        {
            var accountBook = _AccountBookRepository.GetSingle(id);
            _AccountBookRepository.Delete(accountBook);
        }
    }
}