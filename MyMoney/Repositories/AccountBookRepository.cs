using System;
using System.Data.Entity;
using MyMoney.Models;
using System.Linq;

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

        public void Edit(AccountBook accountBook)
        {
            var oldData = _MoneyDb.AccountBook.Find(accountBook.Id);
            _MoneyDb.Entry(oldData).CurrentValues.SetValues(accountBook);
            _MoneyDb.SaveChanges();
        }
    }
}