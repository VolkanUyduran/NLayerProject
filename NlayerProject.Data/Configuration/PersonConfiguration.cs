﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NlayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NlayerProject.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).HasMaxLength(20);
            builder.Property(x => x.Surname).HasMaxLength(20);

            builder.ToTable("Persons");
        }
    }
}
