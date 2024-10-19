/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BakerMate.Services.Recipes;

namespace BakerMate.Repositories.Recipes
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

        Task<IEnumerable<RecipeNameDto>> IRecipeAmountRepository.GetRecipeFullName()
        {
            throw new System.NotImplementedException();
        }
    }
}
