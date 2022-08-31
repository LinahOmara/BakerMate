/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;
using BakerMate.Services.Ingrediant;

namespace BakerMate.Repositories.Ingrediant
{
    internal class IngrediantRepository : RepositoryBase, IIngrediantRepository
    {
        public IngrediantRepository()
        {
        }

        public async Task<int> Create(IngrediantDto newIngrediant)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Update(int ingrediantId, IngrediantDto newIngrediant)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Delete()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Get(IngrediantDto newIngrediant)
        {
            throw new System.NotImplementedException();
        }
    }
}
