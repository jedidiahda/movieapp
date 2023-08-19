using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public interface IRequestDVDRepository
    {
        RequestedDvd Save(RequestedDvd requestedDvd);
        IEnumerable<RequestedDvd> GetAll(int customerId);
        void Delete(int requestId);
    }
}
