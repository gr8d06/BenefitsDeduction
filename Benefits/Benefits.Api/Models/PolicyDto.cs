namespace Benefits.Api.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public decimal PrimaryPrice { get; set; }
        public decimal DependantPrice { get; set; }

    }
}
