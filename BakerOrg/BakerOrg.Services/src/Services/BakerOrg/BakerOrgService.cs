/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abrar.BakerOrg.Services.BakerOrg
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
