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
using BakerMate.Services.Recipes.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BakerMate.Repositories.Recipes
{
    internal class RecipeRepository : RepositoryBase, IRecipeRepository
    {
        private readonly BakerMateContext _dbContext;
        public RecipeRepository(BakerMateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(RecipeDto newRecipe)
        {
            var recipe = new Recipe()
            {
                Name = newRecipe.Name,    
                Description = newRecipe.Description,
                RecipeIngredients = newRecipe.Ingredients.Select(i => new RecipeIngredient
                {
                    IngredientId = i.Id 
                }).ToList(),
            };

            return (await new BaseRepository<Recipe>(_dbContext)
                .InsertAsync(recipe)).Id;
        }

        public async Task<int> CreateRecipeSize(RecipeSizeDto newRecipeAmount)
        {
            var RecipeSize = new RecipeSize()
            {
                RecipieId = newRecipeAmount.RecipieId,
                Multiplier = newRecipeAmount.Multiplier,
                OutputWeight = newRecipeAmount.OutputWeight
            };
            return (await new BaseRepository<RecipeSize>(_dbContext).InsertAsync(RecipeSize)).Id;
        }

        public async Task<int> AddIngredientToRecipe(RecipeIngredientDto recipeIngredientDto)
        {
            var recipeIngredient = new RecipeIngredient()
            {
                RecipieId = recipeIngredientDto.RecipieId,
                IngredientId = recipeIngredientDto.IngredientId,
                IngredientQuantity = recipeIngredientDto.IngredientQuantity,
                UnitOfMeasureId = recipeIngredientDto.UnitOfMeasureId
            };
           return (await new BaseRepository<RecipeIngredient>(_dbContext).InsertAsync(recipeIngredient)).IngredientId;
        }

        public async Task DeleteIngredientFromRecipe(RecipeIngredientDto recipeIngredientDto)
        {
            var recipeIngredient = await new BaseRepository<RecipeIngredient>(_dbContext)
                .SingleOrDefaultAsync(new{recipeIngredientDto.RecipieId,recipeIngredientDto.IngredientId});           
            await new BaseRepository<RecipeIngredient>(_dbContext)
                .DeleteAsync(recipeIngredient);
        }

        public async Task<RecipeDto> Get(int recipeId)
        {
            return await new BaseRepository<Recipe>(_dbContext)
                .GetAll(r => r.Id == recipeId)
                .Select(r => new RecipeDto()
                { 
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    Ingredients = r.RecipeIngredients.Select(i => new IngredientDto
                    {
                        Id = i.IngredientId,
                        Name = i.Ingredient.Name,
                        Price = i.Ingredient.Price,
                    }).ToList(),
                })
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<RecipeNameDto>> GetNames()
        {
            return await new BaseRepository<Recipe>(_dbContext)
                .GetAll()
                .Select(r => new RecipeNameDto()
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();
        }

        public async Task Delete(int id)
        {
            var recipedto = await Get(id);
            var recipe = await new BaseRepository<Recipe>(_dbContext)
                .SingleOrDefaultAsync(recipedto.Id);
            await new BaseRepository<Recipe>(_dbContext).DeleteAsync(recipe);
        }

        public async Task<int> Update(RecipeDto updatedRecipe)
        {
            var recipe = new Recipe()
                {
                Name = updatedRecipe.Name,
                Description = updatedRecipe.Description,
                RecipeIngredients = updatedRecipe.Ingredients.Select(i => new RecipeIngredient
                {
                    IngredientId = i.Id
                }).ToList()
            };     
            return (await new BaseRepository<Recipe>(_dbContext)
                .UpdateAsync(recipe)).Id;
        }

    }
}
