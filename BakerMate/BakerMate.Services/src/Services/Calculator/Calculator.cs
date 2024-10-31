using BakerMate.Domain.Model;
using BakerMate.Services.Ingredients;
using BakerMate.Services.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.Services.src.Services.Calculator
{
    public class Calculator : ServiceBase
    {

        public async Task<Dictionary<Ingredient,double>> CalculateByRecipes(Dictionary<RecipeSize,int> recipeSizes)
        {
            var IngredientQuantities = new Dictionary<Ingredient, double>();
            foreach (var recipeSize in recipeSizes)
            {
                foreach (var recipeIngredient in recipeSize.Key.Recipe.RecipeIngredients)
                {
                    if (!IngredientQuantities.ContainsKey(recipeIngredient.Ingredient))
                    {
                        IngredientQuantities.
                        Add(recipeIngredient.Ingredient, recipeIngredient.IngredientQuantity * recipeSize.Key.Multiplier * recipeSize.Value);
                    }
                    else
                    {
                        IngredientQuantities[recipeIngredient.Ingredient] += recipeIngredient.IngredientQuantity * recipeSize.Key.Multiplier * recipeSize.Value;
                    }
                }
            }
            return IngredientQuantities;
        }
    }
}
