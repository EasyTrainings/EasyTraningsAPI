using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyTraningsAPI.DbContext;

public class AppDbContext: IdentityDbContext<IdentityUser>
{ 
    public DbSet<User.Entities.User> Users { get; set; }
    public DbSet<SeasonTicket.Entities.SeasonTicket>SeasonTickets { get; set; }
    public DbSet<Tranning.Entities.Tranning>Trannings { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}