using System.ComponentModel.DataAnnotations.Schema;
using Backend.Interaction.Domain.Model.Aggregates;
using Backend.Orders.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json; 
using Backend.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

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
        
        //TechnicalSupport
        builder.Entity<TechnicalSupport.TechnicalSupport>().HasKey(f => f.Id);
        builder.Entity<TechnicalSupport.TechnicalSupport>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TechnicalSupport.TechnicalSupport>().Property(f => f.TechnicianId).IsRequired();
        builder.Entity<TechnicalSupport.TechnicalSupport>().Property(f => f.SupportType).IsRequired();
        builder.Entity<TechnicalSupport.TechnicalSupport>().Property(f => f.DateOfRequest).IsRequired();
        builder.Entity<TechnicalSupport.TechnicalSupport>().Property(f => f.StartDate).IsRequired();
        builder.Entity<TechnicalSupport.TechnicalSupport>().Property(f => f.EndDate).IsRequired();
        
        //Technician
        builder.Entity<TechnicalSupport.Technician>().HasKey(f => f.Id);
        builder.Entity<TechnicalSupport.Technician>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TechnicalSupport.Technician>().Property(f => f.Name).IsRequired();
        builder.Entity<TechnicalSupport.Technician>().Property(f => f.Status).IsRequired();
        builder.Entity<TechnicalSupport.Technician>().Property(f => f.Stars).IsRequired();
        
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
        
         // Configurar Component
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.ComponentId).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Name).IsRequired().HasMaxLength(100);
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Description).IsRequired().HasMaxLength(500);
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Price).IsRequired();
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Stock).IsRequired();
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Image).IsRequired().HasMaxLength(200);
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.ProviderId).IsRequired();
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Country).IsRequired().HasMaxLength(50);
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .Property(x => x.Ratings);
    // Conversor para AttributeList (Dictionary)
    var dictionaryToJsonConverter = new ValueConverter<Dictionary<string, string>, string>(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<Dictionary<string, string>>(v) ?? new Dictionary<string, string>());

    var dictionaryComparer = new ValueComparer<Dictionary<string, string>>(
        (c1, c2) => c1.SequenceEqual(c2),
        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        c => c.ToDictionary(entry => entry.Key, entry => entry.Value)
    );

// Configuración de Attributes con OwnsOne
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .OwnsOne(c => c.Attributes, a =>
        {
            a.Property(x => x.AttributeList)
                .HasConversion(dictionaryToJsonConverter)
                .Metadata.SetValueComparer(dictionaryComparer);
            a.Property(x => x.AttributeList)
                .HasColumnName("Attributes")  // Nombrar la columna como "Attributes"
                .IsRequired();
        });

// Conversor para CategoriesList (List<string>)
    var listToJsonConverter = new ValueConverter<List<string>, string>(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<List<string>>(v) ?? new List<string>());

    var listComparer = new ValueComparer<List<string>>(
        (l1, l2) => l1.SequenceEqual(l2),
        l => l.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
        l => l.ToList()
    );

// Configuración de Categories con OwnsOne
    builder.Entity<Component.Domain.Model.Aggregates.Component>()
        .OwnsOne(c => c.Categories, c =>
        {
            c.Property(x => x.CategoriesList)
                .HasConversion(listToJsonConverter)
                .Metadata.SetValueComparer(listComparer);
            c.Property(x => x.CategoriesList)
                .HasColumnName("Categories")  // Nombrar la columna como "Categories"
                .IsRequired();
        });



    
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