using MovieWebApp.Models;

namespace MovieWebApp.Repository
{
    public class RequestDVDRepository : IRequestDVDRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public RequestDVDRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void Delete(int requestId)
        {
            var request = _movieDbContext.RequestedDvds.Where(s=>s.Id == requestId).SingleOrDefault();
            if (request == null) throw new Exception("Request not found");
            _movieDbContext.RequestedDvds.Remove(request);
            _movieDbContext.SaveChanges();
        }

        public IEnumerable<RequestedDvd> GetAll(int customerId)
        {
            return _movieDbContext.RequestedDvds.Where(s=>s.CustomerId==customerId);
        }

        public RequestedDvd Save(RequestedDvd requestedDvd)
        {
            _movieDbContext.RequestedDvds.Add(requestedDvd);
            _movieDbContext.SaveChanges();
            return requestedDvd;
        }
    }
}
