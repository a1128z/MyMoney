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
    }
}