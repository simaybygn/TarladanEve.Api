namespace TarladanEve.Api.Models.Request.Product
{
    public class UpdateProductRequest 
    {
        public int Type { get; set; }
        public string ? Description { get; set; }
        public int ? Price { get; set; }
        public string Name { get; set; }

        //public Guid CreatedUserId { get; set; }
    }
}
