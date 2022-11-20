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
    public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            builder.ToTable(nameof(RecipeIngredient), "BKM");
            builder.HasKey(x => new { x.IngredientId, x.RecipieId });
            builder.HasOne(x => x.Ingredient).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.IngredientId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Recipe).WithMany(x => x.RecipeIngredients).HasForeignKey(x => x.RecipieId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}

