/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BakerMate.Services.Ingrediant;

namespace BakerMate.Controllers.Ingrediant
{
    [ApiExplorerSettings(GroupName = "ingrediant")]
    public class IngrediantController : APIController
    {
        private readonly IIngrediantService _service;

        public IngrediantController(IIngrediantService service)
        {
            _service = service;
        }

        [HttpPost, Route("api/ingrediant")]
        public async Task<ActionResult<int>> Create(IngrediantDto newIngrediant)
        {
            int result = await _service.Create(newIngrediant);
            return Ok(result);
        }

        [HttpPut, Route("api/ingrediant/{id}")]
        public async Task<ActionResult<int>> Update(int ingrediantId, IngrediantDto newIngrediant)
        {
            int result = await _service.Update(ingrediantId, newIngrediant);
            return Ok(result);
        }

        [HttpDelete, Route("api/ingrediant")]
        public async Task<ActionResult<int>> Delete()
        {
            int result = await _service.Delete();
            return Ok(result);
        }

        [HttpGet, Route("api/ingrediant")]
        public async Task<ActionResult<int>> Get(IngrediantDto newIngrediant)
        {
            int result = await _service.Get(newIngrediant);
            return Ok(result);
        }
    }
}
