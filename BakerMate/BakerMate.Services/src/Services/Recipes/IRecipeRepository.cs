/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BakerMate.Domain.Model;

namespace BakerMate.Services.Recipes
{
    public interface IRecipeRepository
    {
        Task<int> Create(RecipeDto newRecipe);

        Task<int> CreateRecipeAmount(RecipeDto newRecipeAmount);

        Task<int> AddIngredientToRecipe(RecipeIngredient recipeIngredient);

        Task DeleteIngredientFromRecipe(RecipeIngredient recipeIngredient);

        Task<RecipeDto> Get(int recipeId);

        Task<IEnumerable<RecipeNameDto>> GetNames();
    }
}
