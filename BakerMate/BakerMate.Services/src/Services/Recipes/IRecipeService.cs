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
    public interface IRecipeService
    {
        Task<int> Create(RecipeDto newRecipe);

        Task<int> CreateRecipeSize(RecipeSizeDto newRecipeSize);

        Task<int> AddIngredientToRecipe(RecipeIngredientDto recipeIngredient);

        Task DeleteIngredientFromRecipe(int id, int ingredientId);

        Task<RecipeDto> Get(int recipeId);

        Task<IEnumerable<RecipeNameDto>> GetNames();
    }
}
