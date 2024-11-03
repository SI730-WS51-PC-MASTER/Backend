using Backend.Interaction.Domain.Model.Aggregates;
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
        
        //Bounded Context Interaction
        //ReviewComponent
        builder.Entity<ReviewComponent>().HasKey(c => c.Id);
        builder.Entity<ReviewComponent>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewComponent>().Property(c => c.Rating).IsRequired();
        builder.Entity<ReviewComponent>().Property(c => c.Comment).IsRequired().HasMaxLength(150);
        builder.Entity<ReviewComponent>().Property(c => c.UserName).IsRequired();
        builder.Entity<ReviewComponent>().Property(c => c.ComponentId).IsRequired();
        builder.Entity<ReviewComponent>().Property(c => c.ComponentName).IsRequired();
        
        
        //ReviewTechnicalSupport
        builder.Entity<ReviewTechnicalSupport>().HasKey(c => c.Id);
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.Rating).IsRequired();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.Comment).IsRequired().HasMaxLength(150);
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.UserName).IsRequired();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.TechnicalSupportId).IsRequired();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.TechnicalSupport).IsRequired();
        
        
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}