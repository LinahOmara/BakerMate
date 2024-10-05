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
using BakerMate.Services.Recipes;
using Microsoft.EntityFrameworkCore;

namespace BakerMate.Repositories.Recipes
{
    internal class RecipeRepository : RepositoryBase, IRecipeRepository
    {
        public RecipeRepository()
        {
        }

        public async Task<int> Create(RecipeDto newRecipe)
        {
            var recipe = new Recipe()
            {
                Name = newRecipe.Name,
                RecipeIngredients = newRecipe.Ingredients.Select(i => new RecipeIngredient
                {
                    IngredientId = i.Id,
                    // fill rest of data 
                }).ToList(),
            };

            return (await new BaseRepository<Recipe>()
                .InsertAsync(recipe)).Id;
        }

        public async Task<int> CreateRecipeAmount(RecipeDto newRecipeAmount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> AddIngredientToRecipe(RecipeIngredient recipeIngredient)
        {
            return 0; // await new BaseRepository<RecipeIngredient>()
                //.InsertAsync(recipeIngredient);
        }

        public async Task DeleteIngredientFromRecipe(RecipeIngredient recipeIngredient)
        {
            await new BaseRepository<RecipeIngredient>()
                .DeleteAsync(recipeIngredient);
        }

        public async Task<RecipeDto> Get(int recipeId)
        {
            return await new BaseRepository<Recipe>()
                .GetAll(r => r.Id == recipeId)
                .Select(r => new RecipeDto()
                { 
                    Id = r.Id,
                    Name = r.Name,
                    Ingredients = r.RecipeIngredients.Select(i => new IngredientDto
                    {
                        Id = i.IngredientId,
                        Name = i.Ingredient.Name,
                        Price = i.Ingredient.Price,
                        UnitOfMeasure = i.Ingredient.UnitOfMeasure.Name
                    }).ToList(),
                })
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<RecipeNameDto>> GetNames()
        {
            return await new BaseRepository<Recipe>()
                .GetAll()
                .Select(r => new RecipeNameDto()
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();
        }
    }
}
