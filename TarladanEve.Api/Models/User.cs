namespace TarladanEve.Api.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int UserType { get; set; }
        public string Address { get; set; }
        public string UserName { get; set; }

    }
}
