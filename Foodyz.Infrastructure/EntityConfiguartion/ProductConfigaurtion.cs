using Foodyz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Foodyz.Infrastructure.EntityConfiguartion
{
    public class ProductConfigaurtion : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.Property(n=> n.Name).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            

        }
    }
}
