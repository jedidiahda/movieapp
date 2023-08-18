namespace MovieWebApp.Service.DTO
{
    public class CustomerDeliveryDTO
    {
        //public int CustomerId { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public int SubscriptionId { get; set; }

        //public DVDCatalogDTO dvdCatalogDTO { get; set; }

        public int customerId { get; set; }
        public int customerSubscriptionId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int DVDCatalogId { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public int rank { get; set; }
        public string code { get; set; }


    }
}
