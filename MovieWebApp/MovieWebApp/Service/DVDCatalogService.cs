using MovieWebApp.Repository;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Service
{
    public class DVDCatalogService
    {
        private readonly IDVDCatalogRepository _dVDCatalogRepository;

        public DVDCatalogService(IDVDCatalogRepository dVDCatalogRepository)
        {
            _dVDCatalogRepository = dVDCatalogRepository;
        }

        public DVDCatalogDTO Save(DVDCatalogDTO dvdcatalogDTO)
        {
            _dVDCatalogRepository.Save(DVDCatalogAdapter.GetDVDCatalog(dvdcatalogDTO));
            return dvdcatalogDTO;
        }
        public DVDCatalogDTO GetById(int id)
        {
            return DVDCatalogAdapter.GetDVDCatalogDTO(_dVDCatalogRepository.GetById(id));
        }
        public DVDCatalogDTO Update(int dvdCatalogId, DVDCatalogDTO dvdcatalogDTO)
        {
            _dVDCatalogRepository.Update(dvdCatalogId, DVDCatalogAdapter.GetDVDCatalog(dvdcatalogDTO));
            return dvdcatalogDTO;
        }

        public IEnumerable<DVDCatalogDTO> GetAll(string title, int limit, int pageNumber)
        {
            var dvdList = _dVDCatalogRepository.GetAll(title, limit, pageNumber).ToList();
            var dvdDTOList = new List<DVDCatalogDTO>();
            foreach(var dvd in dvdList)
            {
                dvdDTOList.Add(DVDCatalogAdapter.GetDVDCatalogDTO(dvd));
            }
            return dvdDTOList;
        }

        public bool Delete(int dvdCatalogId)
        {
            var dvdCatalog = _dVDCatalogRepository.GetById(dvdCatalogId);
            if(dvdCatalog == null)
                return false;

            _dVDCatalogRepository.Delete(dvdCatalog);
            return true;
        }

        public void AddDVDCopy(int dvdCatalogId, DvdcopyDTO dvdcopy)
        {
            _dVDCatalogRepository.AddDVDCopy(dvdCatalogId,DvdcopyAdapter.GetDvdcopy(dvdcopy));
        }

        public IEnumerable<DvdcopyDTO> GetDVDCopies(int dvdCatalogId,string code, int limit, int pageNumber)
        {
            var dvdCopies = _dVDCatalogRepository.GetDVDCopies(dvdCatalogId,code,limit,pageNumber).ToList();
            var dvdCopiesDTO = new List<DvdcopyDTO>();
            foreach(var dvdcopy in dvdCopies)
            {
                dvdCopiesDTO.Add(DvdcopyAdapter.GetDvdcopyDTO(dvdcopy));
            }
            return dvdCopiesDTO;
        }

        public DvdcopyDTO? GetDvdcopy(string code)
        {
            var dvdCopy = _dVDCatalogRepository.GetDvdcopy(code);
            if (dvdCopy == null) return null;
            else
                return DvdcopyAdapter.GetDvdcopyDTO(dvdCopy);
        }

        public DvdcopyDTO? GetDvdcopy(int dvdCopyId)
        {
            var dvdCopy = _dVDCatalogRepository.GetDvdcopy(dvdCopyId);
            if (dvdCopy == null) return null;
            else
                return DvdcopyAdapter.GetDvdcopyDTO(dvdCopy);
        }

        public void DeleteDVDCopy(int dvdCopyId)
        {
            _dVDCatalogRepository.DeleteDVDCopy(dvdCopyId);
        }

        public DvdcopyDTO? UpdateDvdCopy(int id, DvdcopyDTO dvdcopyDTO)
        {
            var dvdCopy = _dVDCatalogRepository.UpdateDvdCopy(id,DvdcopyAdapter.GetDvdcopy(dvdcopyDTO));
            return dvdCopy == null ? null : dvdcopyDTO;
        }
    }
}
