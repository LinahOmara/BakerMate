/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.Services.Ingredients;

namespace BakerMate.Repositories.Ingredients
{
    internal class IngredientRepository : RepositoryBase, IIngredientRepository
    {
        private readonly BakerMateContext _dbContext;

        public IngredientRepository(BakerMateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Ingredient newIngredient)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Update(Ingredient newIngredient)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Ingredient>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Ingredient> Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
