using Foodyz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Infrastructure.EntityConfiguartion
{
    public class PhotoConfiguartion : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(i=> i.Id);
            builder.Property(p=> p.photoPath).IsRequired();
            builder.HasMany(p=> p.Products).WithOne(i=> i.photo);
        }
    }
}
