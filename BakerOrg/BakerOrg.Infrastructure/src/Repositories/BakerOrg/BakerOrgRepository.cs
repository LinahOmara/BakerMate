/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Abrar.BakerOrg.Services.BakerOrg;
using BakerGuru.Common.DB;

namespace Abrar.BakerOrg.Repositories.BakerOrg
{
    internal class BakerOrgRepository : RepositoryBase, IBakerOrgRepository
    {
        private readonly QueryFactory _db;
        private readonly DBContext _dbContext;

        public BakerOrgRepository(QueryFactory db, DBContext dbContext)
        {
            _db = db;
            _dbContext = dbContext;
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
