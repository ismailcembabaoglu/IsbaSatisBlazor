﻿using IsbaSatisBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsbaSatisBlazor.Data.Mappings
{
    public class PaymentMotionMap : IEntityTypeConfiguration<PaymentMotion>
    {
        public void Configure(EntityTypeBuilder<PaymentMotion> builder)
        {
          builder.Property(c => c.Price).HasPrecision(10, 2);
            builder.ToTable("PaymentMotions");
        }
    }
}
