﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Doughnut.Infrastructure.EntityConfiguration
{
    public abstract class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Doughnut.Domain.DomainModels.BaseModel
    {
        public abstract void DomainConfiguration(
            Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder);

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.ToTable(typeof(T).Name).HasKey(u => u.Id);

            builder.Property(u => u.Id).ValueGeneratedNever();

            DomainConfiguration(builder);

            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValue(DateTimeOffset.UtcNow);

            builder.Property(u => u.CreatedBy).IsRequired().HasDefaultValue("System");

            builder.Property(u => u.UpdatedAt).IsRequired().HasDefaultValue(DateTimeOffset.UtcNow);

            builder.Property(u => u.UpdatedBy).IsRequired().HasDefaultValue("System");
        }
    }
}
