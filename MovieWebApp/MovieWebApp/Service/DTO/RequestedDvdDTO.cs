namespace MovieWebApp.Service.DTO
{
    public class RequestedDvdDTO
    {
        public string? Title { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int Id { get; set; }
        public int CustomerId { get; set; }
    }
}
