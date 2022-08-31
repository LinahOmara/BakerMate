/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;
using BakerMate.Services.Recipe;

namespace BakerMate.Repositories.Recipe
{
    internal class RecipeAmountRepository : RepositoryBase, IRecipeAmountRepository
    {
        public RecipeAmountRepository()
        {
        }

        public async Task<int> Create(RecipeAmountDto newRecipeAmount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RecipeAmountDto> GetByRecipeId(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RecipeNameDto> GetRecipeFullName()
        {
            throw new System.NotImplementedException();
        }
    }
}
