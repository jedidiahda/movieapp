using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class DVDCatalogRepository : IDVDCatalogRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public DVDCatalogRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        public void Delete(Dvdcatalog dvdcatalog)
        {
            dvdcatalog.IsDeleted = true;
            _movieDbContext.SaveChanges();
        }

        public IEnumerable<Dvdcatalog> GetAll(string title, int limit, int pageNumber)
        {
            return _movieDbContext.Dvdcatalogs
                .Where(s => s.IsDeleted == false && (string.IsNullOrEmpty(title) || s.Title.Contains(title)))
                .OrderBy(s=>s.Title)
                .Take(limit)
                .Skip((pageNumber-1) * limit)
                .ToList();
        }

        public Dvdcatalog? GetById(int id)
        {
            return _movieDbContext.Dvdcatalogs.Where(s=>s.Id == id).SingleOrDefault();
        }



        public Dvdcatalog Save(Dvdcatalog dvdcatalog)
        {
            _movieDbContext.Dvdcatalogs.Add(dvdcatalog);
            _movieDbContext.SaveChanges();
            return dvdcatalog;
        }

        public Dvdcatalog Update(int dvdCatalogId, Dvdcatalog dvdcatalog)
        {
            var saveDVDCatalog = _movieDbContext.Dvdcatalogs.Where(s=>s.Id == dvdCatalogId).SingleOrDefault();
            if(saveDVDCatalog != null)
            {
                saveDVDCatalog.Title = dvdcatalog.Title;
                saveDVDCatalog.Description = dvdcatalog.Description;
                saveDVDCatalog.Genre = dvdcatalog.Genre;
                saveDVDCatalog.StockQty = dvdcatalog.StockQty;
                saveDVDCatalog.ReleasedDate = dvdcatalog.ReleasedDate;
                saveDVDCatalog.Language = dvdcatalog.Language;
                saveDVDCatalog.NoDisk = dvdcatalog.NoDisk;

                _movieDbContext.SaveChanges();
            }
            return dvdcatalog;
        }

        public void AddDVDCopy(int dvdCatalogId, Dvdcopy dvdcopy)
        {
            var dvdCatalog = GetById(dvdCatalogId);
            if (dvdCatalog != null)
            {
                dvdCatalog.Dvdcopies.Add(dvdcopy);
                _movieDbContext.SaveChanges();
            }
        }

        public void DeleteDVDCopy(int dvdCopyId)
        {
            var dvdCopy = _movieDbContext.Dvdcopies.Where(s => s.Id == dvdCopyId).SingleOrDefault();
            if (dvdCopy != null)
            {
                dvdCopy.IsDeleted = true;
                _movieDbContext.SaveChanges();
            }
        }

        public IEnumerable<Dvdcopy> GetDVDCopies(int dvdCatalogId, string code, int limit, int pageNumber)
        {
            return _movieDbContext.Dvdcopies
                .Where(s => s.DvdcatalogId == dvdCatalogId && (string.IsNullOrEmpty(code) || s.Code.Contains(code)) && s.IsDeleted == false);
        }

        public Dvdcopy? GetDvdcopy(string code)
        {
            return _movieDbContext.Dvdcopies.Where(s => s.Code == code && s.IsDeleted == false).SingleOrDefault() ;
        }
        public Dvdcopy? GetDvdcopy(int dvdCopyId)
        {
            return _movieDbContext.Dvdcopies.Where(s => s.Id == dvdCopyId && s.IsDeleted == false).SingleOrDefault() ;
        }

        public Dvdcopy? UpdateDvdCopy(int id, Dvdcopy dvdcopy)
        {
            var copy = GetDvdcopy(id);
            if(copy != null)
            {
                copy.Status = dvdcopy.Status;
                copy.Code = dvdcopy.Code;
                _movieDbContext.SaveChanges();
                return copy;
            }
            return null;
        }

        public IEnumerable<Dvdcatalog> GetAll(int catalogId)
        {
            return _movieDbContext.Dvdcatalogs.Where(s => s.Id != catalogId);
        }
    }
}
