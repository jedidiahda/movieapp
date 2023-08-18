using System.ComponentModel.DataAnnotations;

namespace MovieWebApp.Service.DTO
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int AtHomeDvd { get; set; }

        public int NoDvdperMonth { get; set; }

        public decimal Price { get; set; }
        public bool IsDeleted { get; set; }

        public SubscriptionDTO(int id,string name, int atHomeDvd, int noDvdperMonth, decimal price,bool isDeleted)
        {
            Id = id;
            Name = name;
            AtHomeDvd = atHomeDvd;
            NoDvdperMonth = noDvdperMonth;
            Price = price;
            IsDeleted = isDeleted;
        }

 

    }
}
