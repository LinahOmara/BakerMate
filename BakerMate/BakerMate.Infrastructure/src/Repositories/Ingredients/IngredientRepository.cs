/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.Services.Ingredients;
using Microsoft.EntityFrameworkCore;

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
            return (await new BaseRepository<Ingredient>()
                .InsertAsync(newIngredient)).Id;
        }

        public async Task<int> Update(Ingredient newIngredient)
        {
            return (await new BaseRepository<Ingredient>()
                .UpdateAsync(newIngredient)).Id;
        }

        public async Task Delete(int id)
        {
            var ing = await Get(id);
            
            await new BaseRepository<Ingredient>()
                .DeleteAsync(ing);
                
        }

        public async Task<IEnumerable<Ingredient>> Get()
        {
            return await new BaseRepository<Ingredient>()
                .GetAll()
                .ToListAsync(); // change to enumberqble async 
        }

        public async Task<Ingredient> Get(int id)
        {
            return await new BaseRepository<Ingredient>()
                .GetAll()
                .SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
