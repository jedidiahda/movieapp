using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public WatchlistRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void Delete(int customerId, int dvdCatalogId)
        {
            var dvdcopy = _movieDbContext.Watchlists.Where(s => s.CustomerId == customerId && s.DvdcatalogId == dvdCatalogId).FirstOrDefault();
            if (dvdcopy == null) throw new Exception("Watchlist item not found");
            _movieDbContext.Watchlists.Remove(dvdcopy);
            _movieDbContext.SaveChanges(); 
        }

        public Watchlist Get(int customerId, int dvdCatalogId)
        {
            return _movieDbContext.Watchlists.Where(s => s.CustomerId == customerId && s.DvdcatalogId == dvdCatalogId).FirstOrDefault();
        }

        public IEnumerable<Watchlist> GetAll(int customerId)
        {
            return from w in _movieDbContext.Watchlists
                       join d in _movieDbContext.Dvdcatalogs on w.DvdcatalogId equals d.Id
                       where w.CustomerId == customerId
                       select new Watchlist
                       {
                           CustomerId = w.CustomerId,
                           Dvdcatalog = d,
                           DvdcatalogId = w.DvdcatalogId,
                           Rank = w.Rank,
                       };

            //return _movieDbContext.Watchlists.Where(s => s.CustomerId == customerId)
        }

        public Watchlist Save(Watchlist watchlist)
        {
            _movieDbContext.Watchlists.Add(watchlist);
            _movieDbContext.SaveChanges();
            return watchlist;
        }

        public Watchlist Update(Watchlist watchlist)
        {
            var saveWatchlist = Get(watchlist.CustomerId, watchlist.DvdcatalogId);
            if (saveWatchlist == null) throw new Exception("Watchlist not found");

            saveWatchlist.Rank = watchlist.Rank;
            _movieDbContext.SaveChanges();
            return saveWatchlist;
        }
    }
}
