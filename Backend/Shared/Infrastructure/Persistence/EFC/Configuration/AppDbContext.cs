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
        /*builder.Entity<ReviewComponent>().HasKey(c => c.Id);
        builder.Entity<ReviewComponent>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewComponent>().Property(c => c.Rating).IsRequired();
        builder.Entity<ReviewComponent>().Property(c => c.Comment).IsRequired().HasMaxLength(150);*/
        //builder.Entity<ReviewComponent>().Property(c => c.UserName).IsRequired();
        //builder.Entity<ReviewComponent>().Property(c => c.ComponentId).IsRequired();
        //builder.Entity<ReviewComponent>().Property(c => c.ComponentName).IsRequired();
        /*builder.Entity<ReviewComponent>().OwnsOne(p => p.UserName.Name, 
            pn =>
            {
                pn.WithOwner().HasForeignKey("Id");
                pn.Property(p => p.Name).IsRequired().HasColumnName("UserName").HasMaxLength(30);
            });*/
        // Configuración de UserName como un tipo propio (owned type)
        /*builder.Entity<ReviewComponent>().OwnsOne(
            rc => rc.UserName,
            userName =>
            {
                userName.WithOwner().HasForeignKey("Id");
                userName.Property(u => u.Name)
                    .IsRequired()
                    .HasColumnName("UserName")
                    .HasMaxLength(30);
            }
        );
        builder.Entity<ReviewComponent>().OwnsOne(
            rc => rc.ComponentId,
            componentId =>
            {
                componentId.WithOwner().HasForeignKey("Id");
                componentId.Property(c => c.Id)
                    .IsRequired()
                    .HasColumnName("ComponentId");
            }
        );
        builder.Entity<ReviewComponent>().OwnsOne(
            rc => rc.ComponentName,
            componentName =>
            {
                componentName.WithOwner().HasForeignKey("Id");
                componentName.Property(c => c.Name)
                    .IsRequired()
                    .HasColumnName("ComponentName")
                    .HasMaxLength(30);
            }
        );*/
        
        // Configuración de la entidad ReviewComponent
        builder.Entity<ReviewComponent>().HasKey(c => c.Id);
        builder.Entity<ReviewComponent>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewComponent>().Property(c => c.Rating).IsRequired();
        builder.Entity<ReviewComponent>().Property(c => c.Comment).IsRequired().HasMaxLength(150);

// Configuración de UserName como un tipo propio (owned type) con prefijo para columnas
        builder.Entity<ReviewComponent>().OwnsOne(
            rc => rc.UserName,
            un =>
            {
                un.WithOwner().HasForeignKey("Id");
                un.Property(rc => rc.Name)
                    .IsRequired()
                    .HasColumnName("UserName") // Prefijo para evitar conflictos de nombres
                    .HasMaxLength(30);
            }
        );

// Configuración de ComponentId como un tipo propio con prefijo para columnas
        builder.Entity<ReviewComponent>().OwnsOne(
            rc => rc.ComponentId,
            cd =>
            {
                cd.WithOwner().HasForeignKey("Id");
                cd.Property(rc => rc.CompId)
                    .IsRequired()
                    .HasColumnName("ComponentId"); // Prefijo para evitar conflictos de nombres
            }
        );

// Configuración de ComponentName como un tipo propio con prefijo para columnas
        builder.Entity<ReviewComponent>().OwnsOne(
            rc => rc.ComponentName,
            cn =>
            {
                cn.WithOwner().HasForeignKey("Id");
                cn.Property(rc => rc.Name)
                    .IsRequired()
                    .HasColumnName("ComponentName") // Prefijo para evitar conflictos de nombres
                    .HasMaxLength(30);
            }
        );

        
        //ReviewTechnicalSupport
        /*builder.Entity<ReviewTechnicalSupport>().HasKey(c => c.Id);
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.Rating).IsRequired();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.Comment).IsRequired().HasMaxLength(150);
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.UserName).IsRequired();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.TechnicalSupportId).IsRequired();
        builder.Entity<ReviewTechnicalSupport>().Property(c => c.TechnicalSupport).IsRequired();*/
        
        
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}