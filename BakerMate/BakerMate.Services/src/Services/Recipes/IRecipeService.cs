/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakerMate.Services.Recipes
{
    public interface IRecipeService
    {
        Task<int> Create(RecipeDto newRecipe);

        Task<int> CreateRecipeAmount(RecipeDto newRecipeAmount);

        Task<int> AddIngredientToRecipe(int id, int ingredientId);

        Task DeleteIngredientFromRecipe(int id, int ingredientId);

        Task<RecipeDto> Get(int recipeId);

        Task<IEnumerable<RecipeNameDto>> GetNames();
    }
}
