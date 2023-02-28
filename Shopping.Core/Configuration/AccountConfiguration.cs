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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.AccountId);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Type).IsRequired().HasDefaultValue(2);
        }
    }
}
