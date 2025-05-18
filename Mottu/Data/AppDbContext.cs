using Microsoft.EntityFrameworkCore;
using MottuTrackerAPI.Models;

namespace MottuTrackerAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Moto> Motos => Set<Moto>();
        public DbSet<Localizacao> Localizacoes => Set<Localizacao>();
    }
}