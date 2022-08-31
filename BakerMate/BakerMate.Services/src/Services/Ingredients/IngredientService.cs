/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BakerMate.Services.Ingredients
{
    internal class IngredientService : ServiceBase, IIngredientService
    {
        private readonly IIngredientRepository _repository;

        public IngredientService(IIngredientRepository repository, BakerMateContext dbContext)
        {
            _repository = repository;
        }

        public async Task<int> Create(IngredientDto newIngredient)
        {
            EnsureExists(newIngredient, "ingrediant object can't be null");
            var ingrediant = new Ingredient
            {
                Name = newIngredient.Name,
                Price = newIngredient.Price,
                UnitOfMeasureId = newIngredient.UnitOfMeasureId,
                PurchaceLocation = newIngredient.PurchaceLocation
            };

            var newId = await _repository.Create(ingrediant);
            return newId;
        }

        public async Task<int> Update(int ingredientId, IngredientDto ingredient)
        {
            EnsureExists(ingredient, "ingrediant object can't be null");
            Assert(ingredientId == ingredient.Id, $"Ids not matching, {ingredientId} and {ingredient.Id}");
            
            var dbIngrediant = await _repository.Get(ingredientId);
            dbIngrediant.Name = ingredient.Name;
            dbIngrediant.Price = ingredient.Price;
            dbIngrediant.PurchaceLocation = ingredient.PurchaceLocation;

            await _repository.Update(dbIngrediant);
            return ingredientId;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<IEnumerable<IngredientDto>> Get()
        {
            return (await _repository.Get())
                .Select(i => new IngredientDto 
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    PurchaceLocation = i.PurchaceLocation,
                    UnitOfMeasureId = i.UnitOfMeasureId
                });
        }

    }
}
