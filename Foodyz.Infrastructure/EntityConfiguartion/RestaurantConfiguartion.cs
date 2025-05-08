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
    public class RestaurantConfiguartion : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(n=> n.Name).IsRequired().HasMaxLength(255);
         
        }
    }
}
