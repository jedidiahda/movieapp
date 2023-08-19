using MovieWebApp.Models;

namespace MovieWebApp.Service.DTO
{
    public class RequestedDvdAdapter
    {
        public static RequestedDvdDTO GetRequestedDvdDTO(RequestedDvd requestedDvd)
        {
            RequestedDvdDTO requestedDvdDTO = new RequestedDvdDTO();
            requestedDvdDTO.Id = requestedDvd.Id;
            requestedDvdDTO.Title = requestedDvd.Title;
            requestedDvdDTO.SubmissionDate = requestedDvd.SubmissionDate;
            requestedDvdDTO.CustomerId = requestedDvd.CustomerId;
            return requestedDvdDTO;
        }

        public static RequestedDvd GetRequestedDvd(RequestedDvdDTO requestedDvdDTO)
        {
            RequestedDvd requestedDvd = new RequestedDvd(); 
            requestedDvd.Id = requestedDvdDTO.Id;
            requestedDvd.Title = requestedDvdDTO.Title;
            requestedDvd.SubmissionDate = requestedDvdDTO.SubmissionDate;
            requestedDvd.CustomerId = requestedDvdDTO.CustomerId;
            return requestedDvd;
        }
    }
}
