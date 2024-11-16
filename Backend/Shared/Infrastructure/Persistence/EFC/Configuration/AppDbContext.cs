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
        //ComponentReview
        builder.Entity<ComponentReview>().HasKey(c => c.Id);
        builder.Entity<ComponentReview>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ComponentReview>().Property(c => c.Rating).IsRequired();
        builder.Entity<ComponentReview>().Property(c => c.Comment).IsRequired().HasMaxLength(150);

        builder.Entity<ComponentReview>().OwnsOne(
            rc => rc.UserName,
            un =>
            {
                un.WithOwner().HasForeignKey("Id");
                un.Property(rc => rc.Name)
                    .IsRequired()
                    .HasColumnName("UserName")
                    .HasMaxLength(30);
            }
        );

        builder.Entity<ComponentReview>().OwnsOne(
            rc => rc.ComponentId,
            cd =>
            {
                cd.WithOwner().HasForeignKey("Id");
                cd.Property(rc => rc.CompId)
                    .IsRequired()
                    .HasColumnName("ComponentId");
            }
        );

        
        //TechnicalSupportReview
        builder.Entity<TechnicalSupportReview>().HasKey(c => c.Id);
        builder.Entity<TechnicalSupportReview>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TechnicalSupportReview>().Property(c => c.Rating).IsRequired();
        builder.Entity<TechnicalSupportReview>().Property(c => c.Comment).IsRequired().HasMaxLength(150);
        
        builder.Entity<TechnicalSupportReview>().OwnsOne(
            rt => rt.UserName,
            tn =>
            {
                tn.WithOwner().HasForeignKey("Id");
                tn.Property(rt => rt.Name)
                    .IsRequired()
                    .HasColumnName("UserName")
                    .HasMaxLength(30);
            }
        );
        
        builder.Entity<TechnicalSupportReview>().OwnsOne(
            tc => tc.TechnicalSupportId,
            td =>
            {
                td.WithOwner().HasForeignKey("Id");
                td.Property(tc => tc.TechSupportId)
                    .IsRequired()
                    .HasColumnName("TechnicalSupportId");
            }
        );
        
        //Wishlist
        builder.Entity<Wishlist>().HasKey(w => w.Id);
        builder.Entity<Wishlist>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Wishlist>().OwnsOne(
            wh => wh.UserId,
            cd =>
            {
                cd.WithOwner().HasForeignKey("Id");
                cd.Property(wh => wh.UsrId)
                    .IsRequired()
                    .HasColumnName("UserId");
            }
        );
        
        builder.Entity<Wishlist>().OwnsOne(
            wi => wi.ComponentName,
            tn =>
            {
                tn.WithOwner().HasForeignKey("Id");
                tn.Property(wi => wi.Name)
                    .IsRequired()
                    .HasColumnName("ComponentName")
                    .HasMaxLength(30);
            }
        );
        builder.Entity<Wishlist>().Property(w => w.QuantityComponents).IsRequired();
        
        
        builder.UseSnakeCaseNamingConvention();

    }
    
}