/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakerMate.Services.Ingredients;

namespace BakerMate.Controllers.Ingredients
{
    [ApiExplorerSettings(GroupName = "Ingredients")]
    public class IngredientController : APIController
    {
        private readonly IIngredientService _service;

        public IngredientController(IIngredientService service)
        {
            _service = service;
        }

        [HttpPost, Route("api/Ingredients")]
        public async Task<ActionResult<int>> Create(IngredientDto newIngredient)
        {
            int result = await _service.Create(newIngredient);
            return Ok(result);
        }

        [HttpPut, Route("api/Ingredients/{id}")]
        public async Task<ActionResult<int>> Update(int ingredientId, IngredientDto newIngredient)
        {
            int result = await _service.Update(ingredientId, newIngredient);
            return Ok(result);
        }

        [HttpDelete, Route("api/Ingredients")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }

        [HttpGet, Route("api/Ingredients")]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> Get()
        {
            IEnumerable<IngredientDto> result = await _service.Get();
            return Ok(result);
        }
    }
}
