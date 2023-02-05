namespace TarladanEve.Api.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string Name { get; set; }

        //public string CreatedUserId { get; set; }

    }
}
