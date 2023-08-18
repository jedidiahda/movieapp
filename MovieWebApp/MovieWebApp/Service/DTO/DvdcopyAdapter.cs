using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class DvdcopyAdapter
    {
        public static Dvdcopy​ GetDvdcopy(DvdcopyDTO dvdcopyDTO)
        {
            Dvdcopy dvdcopy = new Dvdcopy();
            dvdcopy.Id = dvdcopyDTO.ID;
            dvdcopy.Status = dvdcopyDTO.Status;
            dvdcopy.Code = dvdcopyDTO.Code;
            dvdcopy.DvdcatalogId=dvdcopyDTO.DvdcatalogId;
            dvdcopy.IsDeleted= dvdcopyDTO.IsDeleted;
            return dvdcopy;
        }

        public static DvdcopyDTO GetDvdcopyDTO(Dvdcopy dvdcopy)
        {
            DvdcopyDTO dvdcopyDTO = new DvdcopyDTO();
            dvdcopyDTO.ID = dvdcopy.Id;
            dvdcopyDTO.DvdcatalogId = dvdcopy.DvdcatalogId;
            dvdcopyDTO.Status = dvdcopy.Status;
            dvdcopyDTO.Code = dvdcopy.Code;
            dvdcopyDTO.IsDeleted= dvdcopy.IsDeleted;
            return dvdcopyDTO;
        }
    }
}
