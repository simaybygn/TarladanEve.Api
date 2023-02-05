using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TarladanEve.Api.Models;
using TarladanEve.Api.Models.User;

namespace TarladanEve.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)       ///DbContextOptions generic sınıf
        {
        }

        public DbSet<User> Users { get; set; }     ///    User'ı Users tablosuna bağlama

        public DbSet<Product> Products { get; set; }
    }
}
