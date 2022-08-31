/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakerMate.Services.BakerOrg
{
    internal class BakerOrgService : ServiceBase, IBakerOrgService
    {
        private readonly IBakerOrgRepository _repository;

        public BakerOrgService(IBakerOrgRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RecipeWightDto>> GetWightPerRecipe(List<int> recipesId)
        {
            return await _repository.GetWightPerRecipe(recipesId);
        }

        public async Task<IEnumerable<IngrediantCountDto>> GetIngrediantsCout(List<int> recipesId)
        {
            return await _repository.GetIngrediantsCout(recipesId);
        }

        public async Task<IEnumerable<RecipeWightAndIngrediantCountDto>> GetRecipeWeightAndIngrediantsCout(List<int> recipesId)
        {
            return await _repository.GetRecipeWeightAndIngrediantsCout(recipesId);
        }
    }
}
