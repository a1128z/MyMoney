namespace MyMoney.Models
{
    using System.Data.Entity;

    public partial class MoneyDb : DbContext
    {
        public MoneyDb()
            : base("name=MoneyDb")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
