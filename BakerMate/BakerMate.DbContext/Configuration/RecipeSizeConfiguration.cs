using BakerMate.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.DbContext.Configuration
{
    public class RecipeSizeConfiguration : IEntityTypeConfiguration<RecipeSize>
    {
        public void Configure(EntityTypeBuilder<RecipeSize> builder)
        {
            builder.ToTable(nameof(RecipeSize), "BKM");
            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeSizes).HasForeignKey(x => x.RecipieId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

