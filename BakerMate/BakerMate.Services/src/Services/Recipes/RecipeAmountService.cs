/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakerMate.Services.Recipes
{
    internal class RecipeAmountService : ServiceBase, IRecipeAmountService
    {
        private readonly IRecipeAmountRepository _repository;

        public RecipeAmountService(IRecipeAmountRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(RecipeAmountDto newRecipeAmount)
        {
            return await _repository.Create(newRecipeAmount);
        }

        public async Task<RecipeAmountDto> GetByRecipeId(int id)
        {
            return await _repository.GetByRecipeId(id);
        }

        public async Task<IEnumerable<RecipeNameDto>> GetRecipeFullName()
        {
            //return await _repository.GetRecipeFullName();
            throw new System.Exception();
        }
    }
}
