using API_Futebol.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Futebol.Context
{
    public class FutebolDBContext : DbContext
    {
        public FutebolDBContext(DbContextOptions<FutebolDBContext> options) : base(options)
        {
        }

        public DbSet<Jogadores> Jogadores { get; set; }
        public DbSet<Futebol> Futebols { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
    }
}