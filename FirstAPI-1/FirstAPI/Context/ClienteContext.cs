using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}