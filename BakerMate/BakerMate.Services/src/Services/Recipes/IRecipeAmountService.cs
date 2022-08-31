/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;

namespace BakerMate.Services.Recipes
{
    public interface IRecipeAmountService
    {
        Task<int> Create(RecipeAmountDto newRecipeAmount);

        Task<RecipeAmountDto> GetByRecipeId(int id);

        Task<RecipeNameDto> GetRecipeFullName();
    }
}
