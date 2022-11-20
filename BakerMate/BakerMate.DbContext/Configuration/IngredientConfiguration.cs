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
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable(nameof(Ingredient), "BKM");
            builder.HasOne(x => x.UnitOfMeasure).WithMany(x=>x.Ingredients).HasForeignKey(x => x.UnitOfMeasureId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
