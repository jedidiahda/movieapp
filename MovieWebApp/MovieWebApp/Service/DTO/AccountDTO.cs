namespace MovieWebApp.Service.DTO
{
    public class AccountDTO
    {
        public string? Email { get; set; } 

        public string? Password { get; set; } 

        public bool Active { get; set; }

        public string? Role { get; set; }
    }
}
