using MyMoney.Models;
using System;
using System.Linq;

namespace MyMoney.Repositories
{
    public interface IAccountBookRepository : IDisposable
    {
        IQueryable<AccountBook> GetAll();
    }
}