using Microsoft.EntityFrameworkCore;
using CrudClients.Models;

namespace CrudClients
{
    public class ClientContext : DbContext
    {
        public ClientContext (DbContextOptions<ClientContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Telphone> Telphones { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}