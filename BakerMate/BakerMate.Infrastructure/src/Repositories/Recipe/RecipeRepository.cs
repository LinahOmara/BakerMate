/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;
using BakerMate.Services.Recipe;

namespace BakerMate.Repositories.Recipe
{
    internal class RecipeRepository : RepositoryBase, IRecipeRepository
    {
        public RecipeRepository()
        {
        }

        public async Task<int> Create(RecipeDto newRecipe)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public async Task<RecipeNameDto> GetNames()
        {
            throw new System.NotImplementedException();
        }
    }
}
