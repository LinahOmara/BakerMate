using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Domain.Model
{
    public class RecipeIngredient
    {
        public int RecipieId { get; set; }
        public int IngredientId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public double IngredientQuantity { get; set; }
        public UnitOfMeasure IngredientQuantityUnit { get; set; }
        public Recipe Recipe { get; set; }
        public Ingredient Ingredient { get; set; }


    }
}
