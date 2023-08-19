using MovieWebApp.Models;
using MovieWebApp.Repository;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Service
{
    public class RequestDVDService
    {
        private readonly IRequestDVDRepository _requestDVDRepository;
        public RequestDVDService(IRequestDVDRepository requestDVDRepository)
        {
            _requestDVDRepository = requestDVDRepository;
        }
        public void Delete(int requestId)
        {
            _requestDVDRepository.Delete(requestId);
        }

        public IEnumerable<RequestedDvd> GetAll(int customerId)
        {
            return _requestDVDRepository.GetAll(customerId);
        }

        public RequestedDvd Save(RequestedDvdDTO requestedDvd)
        {
            return _requestDVDRepository.Save(RequestedDvdAdapter.GetRequestedDvd(requestedDvd));
        }
    }
}
