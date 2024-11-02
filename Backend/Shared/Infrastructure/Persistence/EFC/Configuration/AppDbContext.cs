using Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Backend.TechnicalSupport;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(optionsBuilder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Aquí el obvio error pero es porque debemos crear el bd y bla blabla
        
        //TechnicalSupport
        builder.Entity<Advice>().HasKey(f => f.Id);
        builder.Entity<Advice>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Advice>().Property(f => f.TechnicianId).IsRequired();
        builder.Entity<Advice>().Property(f => f.TechnicalSupportApiKey).IsRequired();
        builder.Entity<Advice>().Property(f => f.SupportType).IsRequired();
        builder.Entity<Advice>().Property(f => f.DateOfRequest).IsRequired();
        builder.Entity<Advice>().Property(f => f.StartDate).IsRequired();
        builder.Entity<Advice>().Property(f => f.EndDate).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}