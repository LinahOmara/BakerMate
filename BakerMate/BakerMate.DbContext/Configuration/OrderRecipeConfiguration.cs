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
            builder.ToTable(nameof(OrderRecipe), "BKM");
            builder.HasKey(x => new { x.OrderId, x.RecipeId });
            builder.HasOne(x => x.Order).WithMany(x => x.Recipes).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Recipe).WithMany(x => x.Orders).HasForeignKey(x => x.RecipeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
