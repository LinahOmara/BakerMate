using BakerMate.Domain.Model;
using BakerMate.Services.Ingredients;
using BakerMate.Services.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Services.Recipes.DTOs
{
    public class RecipeIngredientDto
    {
        public int RecipieId { get; set; }
        public int IngredientId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public double IngredientQuantity { get; set; }
        public RecipeDto Recipe { get; set; }
        public IngredientDto Ingredient { get; set; }


    }
}
