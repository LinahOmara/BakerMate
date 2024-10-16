/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakerMate.Services.Recipes;
using BakerMate.Services.Recipes.DTOs;

namespace BakerMate.Controllers.Recipes
{
    [ApiExplorerSettings(GroupName = "recipes")]
    public class RecipeController : APIController
    {
        private readonly IRecipeService _service;

        public RecipeController(IRecipeService service)
        {
            _service = service;
        }

        [HttpPost, Route("api/recipe")]
        public async Task<ActionResult<int>> Create(RecipeDto newRecipe)
        {
            int result = await _service.Create(newRecipe);
            return Ok(result);
        }

        [HttpPost, Route("api/recipe/size")]
        public async Task<ActionResult<int>> CreateRecipeSize(RecipeSizeDto newRecipeSize)
        {
            int result = await _service.CreateRecipeSize(newRecipeSize);
            return Ok(result);
        }

        [HttpPost, Route("api/recipe/{id}/ingredient")]
        public async Task<ActionResult<int>> AddIngredientToRecipe(RecipeIngredientDto recipeIngredient)
        {
            int result = await _service.AddIngredientToRecipe(recipeIngredient);
            return Ok(result);
        }

        [HttpDelete, Route("api/recipe/{id}/ingrediant")]
        public async Task<ActionResult> DeleteIngredientFromRecipe(int id, int ingredientId)
        {
            await _service.DeleteIngredientFromRecipe(id, ingredientId);
            return Ok();
        }

        [HttpGet, Route("api/recipe/{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int recipeId)
        {
            RecipeDto result = await _service.Get(recipeId);
            return Ok(result);
        }

        [HttpGet, Route("api/recipe/name")]
        public async Task<ActionResult<IEnumerable<RecipeNameDto>>> GetNames()
        {
            IEnumerable<RecipeNameDto> result = await _service.GetNames();
            return Ok(result);
        }
    }
}
