namespace TarladanEve.Api.Models.Request.Product
{
    public class GetAndDeleteProductRequest
    {
        public Guid Id { get; set; }
        public string ? Name { get; set; }
        //public string ? CreatedUserName { get; set; }
    }
}
