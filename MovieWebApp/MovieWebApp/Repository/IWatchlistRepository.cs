using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public interface IWatchlistRepository
    {
        public Watchlist Save(Watchlist watchlist);
        public Watchlist Update(Watchlist watchlist);
        public IEnumerable<Watchlist> GetAll(int customerId);
        public Watchlist Get(int customerId,int dvdCatalogId);
        public void Delete(int customerId, int dvdCatalogId);

    }
}
