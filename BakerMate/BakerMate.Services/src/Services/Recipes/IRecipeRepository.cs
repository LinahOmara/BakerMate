/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using BakerMate.Services.Recipes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakerMate.Services.Recipes
{
    public interface IRecipeRepository
    {
        Task<int> Create(RecipeDto newRecipe);

        Task<int> CreateRecipeAmount(RecipeDto newRecipeAmount);

        Task<int> AddIngredientToRecipe(RecipeIngredientDto recipeIngredient);

        Task Update(RecipeDto updatedRecipe);

        Task DeleteIngredientFromRecipe(RecipeIngredientDto recipeIngredient);

        Task Delete(int id);

        Task<RecipeDto> Get(int recipeId);

        Task<IEnumerable<RecipeNameDto>> GetNames();
    }
}
