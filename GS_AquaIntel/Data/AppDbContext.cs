using Microsoft.EntityFrameworkCore;
using GS_AquaIntel.Models;

namespace GS_AquaIntel.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
}
