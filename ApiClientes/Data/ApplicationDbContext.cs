using Microsoft.EntityFrameworkCore;
using ApiClientes.Models;

namespace ApiClientes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<InformacionGeneral> InformacionGenerales { get; set; }
    }
}