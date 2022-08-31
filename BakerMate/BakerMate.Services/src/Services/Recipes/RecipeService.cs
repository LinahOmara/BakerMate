/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

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

        public async Task<int> AddIngrediantToRecipe(int id, int ingrediantId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> DeleteIngrediantFromRecipe(int id, int ingrediantId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RecipeDto> Get(int recipeId)
        {
            return await _repository.Get(recipeId);
        }

        public async Task<RecipeNameDto> GetNames()
        {
            return await _repository.GetNames();
        }
    }
}
