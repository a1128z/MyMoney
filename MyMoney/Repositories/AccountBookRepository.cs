using System;
using MyMoney.Models;
using System.Linq;
using System.Linq.Expressions;
using MyMoney.ViewModels;

namespace MyMoney.Repositories
{
    public class AccountBookRepository : IAccountBookRepository
    {
        private MoneyDb _MoneyDb;

        public AccountBookRepository()
        {
            _MoneyDb = new MoneyDb();
        }

        public void Dispose()
        {
            _MoneyDb.Dispose();
        }

        public IQueryable<AccountBook> GetAll()
        {
            return _MoneyDb.Set<AccountBook>();
        }

        public void Add(AccountBook accountBook)
        {
            _MoneyDb.AccountBook.Add(accountBook);
            _MoneyDb.SaveChanges();
        }

        public AccountBook GetSingle(Guid id)
        {
           return _MoneyDb.AccountBook.SingleOrDefault(x => x.Id == id);
        }
    }
}