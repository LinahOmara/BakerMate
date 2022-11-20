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
    public class RecipeBaseCountConfiguration : IEntityTypeConfiguration<RecipeBaseCount>
    {
        public void Configure(EntityTypeBuilder<RecipeBaseCount> builder)
        {
            builder.ToTable(nameof(RecipeBaseCount), "BKM");
            builder.HasOne(x => x.Recipe).WithMany().HasForeignKey(x => x.RecipieId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
