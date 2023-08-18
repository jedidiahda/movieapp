using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public AccountRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public Account Get(string email,string password)
        {
            return _movieDbContext.Accounts.Where(s => s.Email == email && s.Password == password).SingleOrDefault();
        }

        public Account Save(Account account)
        {
            account.Active = true;
            _movieDbContext.Accounts.Add(account);
            _movieDbContext.SaveChanges();
            return account;
        }
    }
}
