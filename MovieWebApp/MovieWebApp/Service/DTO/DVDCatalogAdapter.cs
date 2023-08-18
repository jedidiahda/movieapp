using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class DVDCatalogAdapter
    {
        public static DVDCatalogDTO GetDVDCatalogDTO(Dvdcatalog dVDCatalog)
        {
            if(dVDCatalog == null) return null; 
            DVDCatalogDTO dVDCatalogDTO = new DVDCatalogDTO();
            dVDCatalogDTO.Id = dVDCatalog.Id;
            dVDCatalogDTO.Title = dVDCatalog.Title;
            dVDCatalogDTO.Language = dVDCatalog.Language??"";
            dVDCatalogDTO.Description = dVDCatalog.Description??"";
            dVDCatalogDTO.StockQty= dVDCatalog.StockQty;
            dVDCatalogDTO.Genre = dVDCatalog.Genre??"";
            dVDCatalogDTO.NoDisk = dVDCatalog.NoDisk;
            dVDCatalogDTO.ReleasedDate = dVDCatalog.ReleasedDate;
            dVDCatalogDTO.IsDeleted = dVDCatalog.IsDeleted;
            return dVDCatalogDTO;
        }

        public static Dvdcatalog GetDVDCatalog(DVDCatalogDTO dVDCatalogDTO)
        {
            if (dVDCatalogDTO == null) return null;

            Dvdcatalog dvdcatalog = new Dvdcatalog();
            dvdcatalog.Id = dVDCatalogDTO.Id;
            dvdcatalog.Title = dVDCatalogDTO.Title;
            dvdcatalog.Language = dVDCatalogDTO.Language;
            dvdcatalog.Description = dVDCatalogDTO.Description;
            dvdcatalog.Genre = dVDCatalogDTO.Genre;
            dvdcatalog.StockQty = dVDCatalogDTO.StockQty;
            dvdcatalog.NoDisk = dVDCatalogDTO.NoDisk;
            dvdcatalog.ReleasedDate = dVDCatalogDTO.ReleasedDate;
            dvdcatalog.IsDeleted = dVDCatalogDTO.IsDeleted;
            return dvdcatalog;
        }
    }
}
