using MovieWebApp.Models;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Repository
{
    public interface ICustomerDeliveryRepository
    {

        public abstract List<CustomerDeliveryDTO> GetValidCustomerDelivery();
        public abstract List<CustomerReturnDTO> GetDvdstatuses();
        public abstract void SendDvdToCustomer(int susubscriptionId,string code,int dvdCatalogId);
        public abstract void ReturnDVDFromCustomer(int susubscriptionId, string code, int dvdCatalogId);
    }
}
