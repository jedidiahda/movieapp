using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public interface IDVDCatalogRepository
    {
        public Dvdcatalog Save(Dvdcatalog dvdcatalog);
        public Dvdcatalog GetById(int id);
        public Dvdcatalog Update(int dvdCatalogId,Dvdcatalog dvdcatalog);

        public IEnumerable<Dvdcatalog> GetAll(string title, int limit, int pageNumber);
        public IEnumerable<Dvdcatalog> GetAll(int catalogId);
        public void Delete(Dvdcatalog dvdcatalog);

        public void AddDVDCopy(int dvdCatalogId, Dvdcopy dvdcopy);
        public IEnumerable<Dvdcopy> GetDVDCopies(int dvdCatalogId,string code, int limit,int pageNumber);
        public Dvdcopy GetDvdcopy(int dvdCopyId);
        public Dvdcopy GetDvdcopy(string code);
        public void DeleteDVDCopy(int dvdCopyId);
        public Dvdcopy UpdateDvdCopy(int id,Dvdcopy dvdcopy);

    }
}
