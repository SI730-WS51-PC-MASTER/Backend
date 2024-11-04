using Backend.Orders.Domain.Model.Aggregates;
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
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
        /*builder.Entity<FavoriteSource>().HasKey(f => f.Id);
        builder.Entity<FavoriteSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FavoriteSource>().Property(f => f.SourceId).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.NewsApiKey).IsRequired();*/
        
        
        
        
        
        
        // Cart DbSet
        builder.Entity<Cart>().HasKey(f => f.Id);
        builder.Entity<Cart>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Cart>().Property(f => f.ComponentId).IsRequired();
        builder.Entity<Cart>().Property(f => f.UserId).IsRequired();
        builder.Entity<Cart>().Property(f => f.Quantity).IsRequired();
        builder.Entity<Cart>().Property(f => f.CreatedDate).IsRequired();
        builder.Entity<Cart>().Property(f => f.UpdatedDate).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}