using Microsoft.EntityFrameworkCore;
using ClientesApi.Models;
using System.Collections.Generic;

namespace ClientesApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
}
