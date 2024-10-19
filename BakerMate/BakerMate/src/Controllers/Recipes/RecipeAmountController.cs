/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakerMate.Services.Recipes;

namespace BakerMate.Controllers.Recipes
{
    [ApiExplorerSettings(GroupName = "recipes")]
    public class RecipeAmountController : APIController
    {
        private readonly IRecipeAmountService _service;

        public RecipeAmountController(IRecipeAmountService service)
        {
            _service = service;
        }

        [HttpPost, Route("api/recipeAmount")]
        public async Task<ActionResult<int>> Create(RecipeAmountDto newRecipeAmount)
        {
            int result = await _service.Create(newRecipeAmount);
            return Ok(result);
        }

        [HttpGet, Route("api/recipe/{id}/amount")]
        public async Task<ActionResult<RecipeAmountDto>> GetByRecipeId(int id)
        {
            RecipeAmountDto result = await _service.GetByRecipeId(id);
            return Ok(result);
        }

        [HttpGet, Route("api/recipe/name")]
        public async Task<ActionResult<IEnumerable<RecipeNameDto>>> GetRecipeSizes()
        {
            IEnumerable<RecipeNameDto> result = await _service.GetRecipeSizes();
            return Ok(result);
        }
    }
}
