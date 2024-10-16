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
    internal class RecipeService : ServiceBase, IRecipeService
    {
        private readonly IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(RecipeDto newRecipe)
        {
            return await _repository.Create(newRecipe);
        }

        public async Task<int> CreateRecipeAmount(RecipeDto newRecipeAmount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddIngredientToRecipe(RecipeIngredientDto recipeIngredientDto)
        {
            return await _repository.AddIngredientToRecipe(recipeIngredientDto);
        }
        public async Task DeleteIngredientFromRecipe(int id, int ingredientId)
        {
            RecipeIngredientDto recipeIngredientDto = new()
            {
               RecipieId = id,
               IngredientId = ingredientId
            };
             await _repository.DeleteIngredientFromRecipe(recipeIngredientDto);
        }

        public async Task<RecipeDto> Get(int recipeId)
        {
            return await _repository.Get(recipeId);
        }

        public async Task<IEnumerable<RecipeNameDto>> GetNames()
        {
            return await _repository.GetNames();
        }
    }
}
