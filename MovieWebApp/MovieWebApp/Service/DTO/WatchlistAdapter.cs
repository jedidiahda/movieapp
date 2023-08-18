using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class WatchlistAdapter
    {
        public static WatchlistDTO GetWatchlistDTO(Watchlist watchlist)
        {
            var watchlistDTO = new WatchlistDTO();
            watchlistDTO.CustomerId = watchlist.CustomerId;
            watchlistDTO.DvdcatalogId = watchlist.DvdcatalogId;
            watchlistDTO.Rank = watchlist.Rank ?? 0;
            watchlistDTO.Dvdcatalog = DVDCatalogAdapter.GetDVDCatalogDTO(watchlist.Dvdcatalog);
            return watchlistDTO;
        }

        public static Watchlist GetWatchlist(WatchlistDTO watchlistDTO)
        {
            var watchlist = new Watchlist();
            watchlist.CustomerId = watchlistDTO.CustomerId;
            watchlist.Rank = watchlistDTO.Rank;
            watchlist.DvdcatalogId = watchlistDTO.DvdcatalogId;
            return watchlist;
        }
    }
}
