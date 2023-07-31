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
    public class OrderRecipeConfiguration : IEntityTypeConfiguration<OrderRecipe>
    {
        public void Configure(EntityTypeBuilder<OrderRecipe> builder)
        {
            builder.ToTable(nameof(OrderRecipe));
            builder.HasKey(x => new { x.RecipeBaseCountId , x.OrderId });
            builder.HasOne(x => x.RecipeBaseCount).WithMany(x => x.OrderRecipes).HasForeignKey(x => x.RecipeBaseCountId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Order).WithMany(x => x.OrderRecipes).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
