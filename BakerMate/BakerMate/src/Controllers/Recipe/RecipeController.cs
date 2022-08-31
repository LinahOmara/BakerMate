/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakerMate.Services.Recipe;

namespace BakerMate.Controllers.Recipe
{
    [ApiExplorerSettings(GroupName = "recipe")]
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

        [HttpPost, Route("api/recipe/amount")]
        public async Task<ActionResult<int>> CreateRecipeAmount(RecipeDto newRecipeAmount)
        {
            int result = await _service.CreateRecipeAmount(newRecipeAmount);
            return Ok(result);
        }

        [HttpPost, Route("api/recipe/{id}/ingrediant")]
        public async Task<ActionResult<int>> AddIngrediantToRecipe(int id, int ingrediantId)
        {
            int result = await _service.AddIngrediantToRecipe(id, ingrediantId);
            return Ok(result);
        }

        [HttpDelete, Route("api/recipe/{id}/ingrediant")]
        public async Task<ActionResult<int>> DeleteIngrediantFromRecipe(int id, int ingrediantId)
        {
            int result = await _service.DeleteIngrediantFromRecipe(id, ingrediantId);
            return Ok(result);
        }

        [HttpGet, Route("api/recipe/{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int recipeId)
        {
            RecipeDto result = await _service.Get(recipeId);
            return Ok(result);
        }

        [HttpGet, Route("api/recipe/name")]
        public async Task<ActionResult<RecipeNameDto>> GetNames()
        {
            RecipeNameDto result = await _service.GetNames();
            return Ok(result);
        }
    }
}
