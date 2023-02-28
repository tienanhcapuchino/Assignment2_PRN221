using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopping.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.QuantityPerUnit).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.Property(x => x.ProductImage).IsRequired();
        }
    }
}
