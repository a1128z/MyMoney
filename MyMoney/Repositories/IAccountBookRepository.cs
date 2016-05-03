using MyMoney.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using MyMoney.ViewModels;

namespace MyMoney.Repositories
{
    public interface IAccountBookRepository : IDisposable
    {
        IQueryable<AccountBook> GetAll();
        void Add(AccountBook accountBook);
        AccountBook GetSingle(Guid id);
        void Edit(AccountBook accountBook);
        void Delete(AccountBook accountBook);
    }
}