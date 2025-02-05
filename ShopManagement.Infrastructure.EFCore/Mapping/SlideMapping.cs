﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable(nameof(Slide));
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Text).HasMaxLength(255).IsRequired(false);
            builder.Property(x => x.Link).IsRequired(false);
            builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();
        }
    }
}
