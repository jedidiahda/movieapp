using MovieWebApp.Models;
using MovieWebApp.Repository;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Service
{
    public class WatchlistService
    {
        private readonly IWatchlistRepository _watchlistRepository;

        public WatchlistService(IWatchlistRepository watchlistRepository)
        {
            _watchlistRepository = watchlistRepository;
        }

        public WatchlistDTO Get(int customerId, int dvdCatalogId)
        {
            var dvdList = _watchlistRepository.Get(customerId, dvdCatalogId);
            


            return WatchlistAdapter.GetWatchlistDTO(_watchlistRepository.Get(customerId, dvdCatalogId));
        }
        public IEnumerable<WatchlistDTO> GetAll(int customerId)
        {
            var watchlist = _watchlistRepository.GetAll(customerId);
            var newList = new List<WatchlistDTO>();
            foreach (var item in watchlist)
            {
                newList.Add(WatchlistAdapter.GetWatchlistDTO(item));
            }
            return newList;
        }
        public WatchlistDTO Save(WatchlistDTO watchlist)
        {
            return WatchlistAdapter.GetWatchlistDTO(_watchlistRepository.Save(WatchlistAdapter.GetWatchlist(watchlist)));
        }

        public WatchlistDTO Update(Watchlist watchlist)
        {
            return WatchlistAdapter.GetWatchlistDTO(_watchlistRepository.Update(watchlist));
        }

        public void Delete(int customerId,int dvdCopyId)
        {
            _watchlistRepository.Delete(customerId, dvdCopyId);
        }
    }
}
