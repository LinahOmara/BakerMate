/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;

namespace BakerMate.Services.Recipes
{
    public interface IRecipeRepository
    {
        Task<int> Create(RecipeDto newRecipe);

        Task<int> CreateRecipeAmount(RecipeDto newRecipeAmount);

        Task<int> AddIngrediantToRecipe(int id, int ingrediantId);

        Task<int> DeleteIngrediantFromRecipe(int id, int ingrediantId);

        Task<RecipeDto> Get(int recipeId);

        Task<RecipeNameDto> GetNames();
    }
}
