﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartFarm.Data.Entities;

namespace SmartFarm.Data.Configurations
{
    public class InputConfiguration : IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder)
        {
            builder.ToTable("INPUT");
            builder.HasKey(input => input.Id);
            builder.Property(input => input.LoaiThietBi);
            builder.Property(input => input.Max);
            builder.Property(input => input.Min);
            builder.Property(input => input.ThoiGianTruyXuat);
            builder.Property(input => input.ViTriTrangTrai);
            builder.HasOne(equipment => equipment.Equipment)
                .WithOne(input => input.Input)
                .HasForeignKey<Input>(input => input.Id);
        }
    }
}
