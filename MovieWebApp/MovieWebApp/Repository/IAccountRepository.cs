using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public interface IAccountRepository
    {
        public Account Save(Account account);
        public Account Get(string email,string password);
    }
}
