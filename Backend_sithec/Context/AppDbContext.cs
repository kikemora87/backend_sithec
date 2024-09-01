using Backend_sithec.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Backend_sithec.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }
        public DbSet<Humano> Humano { get; set; }
    }
}
