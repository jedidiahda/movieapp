using MovieWebApp.Models;
using MovieWebApp.Repository;
using MovieWebApp.Service.DTO;

namespace MovieWebApp.Service
{
    public class CustomerDeliveryService
    {

        private readonly ICustomerDeliveryRepository _customerDeliverRepository;

        public CustomerDeliveryService(ICustomerDeliveryRepository customerDeliveryRepository)
        {
            _customerDeliverRepository = customerDeliveryRepository;
        }


        public List<CustomerDeliveryDTO> GetValidCustomerDelivery()
        {
            var list = _customerDeliverRepository.GetValidCustomerDelivery();
            return list;
        }

        public void SendDvdToCustomer(int susubscriptionId, string code,int dvdCatalogId)
        {
            _customerDeliverRepository.SendDvdToCustomer(susubscriptionId,code, dvdCatalogId);
        }

        public List<CustomerReturnDTO> GetDvdstatuses()
        {
            return _customerDeliverRepository.GetDvdstatuses();
        }

        public void ReturnDVDFromCustomer(int susubscriptionId, string code, int dvdCatalogId)
        {
            _customerDeliverRepository.ReturnDVDFromCustomer(susubscriptionId,code,dvdCatalogId);
        }
    }
}
