﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(x => x.MedicamentId);
            builder.Property(x => x.Name).HasMaxLength(250).IsUnicode();

            builder.HasMany(x => x.Prescription).WithOne(x => x.Medicament).HasForeignKey(x => x.MedicamentId);
        }
    }
}
