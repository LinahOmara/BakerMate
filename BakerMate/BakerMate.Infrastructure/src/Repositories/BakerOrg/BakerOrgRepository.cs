/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BakerMate.Services.BakerOrg;

namespace BakerMate.Repositories.BakerOrg
{
    internal class BakerOrgRepository : RepositoryBase, IBakerOrgRepository
    {
        public BakerOrgRepository()
        {
        }

        public async Task<IEnumerable<RecipeWightDto>> GetWightPerRecipe(List<int> recipesId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<IngrediantCountDto>> GetIngrediantsCout(List<int> recipesId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<RecipeWightAndIngrediantCountDto>> GetRecipeWeightAndIngrediantsCout(List<int> recipesId)
        {
            throw new System.NotImplementedException();
        }
    }
}
