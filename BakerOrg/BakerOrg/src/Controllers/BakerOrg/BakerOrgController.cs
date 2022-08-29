/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abrar.BakerOrg.Services.BakerOrg;

namespace Abrar.BakerOrg.Controllers.BakerOrg
{
    [ApiExplorerSettings(GroupName = "baker-org")]
    public class BakerOrgController : APIController
    {
        private readonly IBakerOrgService _service;

        public BakerOrgController(IBakerOrgService service)
        {
            _service = service;
        }

        [HttpPost, Route("api/bakerOrg/getRecipeWight")]
        public async Task<ActionResult<IEnumerable<RecipeWightDto>>> GetWightPerRecipe(List<int> recipesId)
        {
            IEnumerable<RecipeWightDto> result = await _service.GetWightPerRecipe(recipesId);
            return Ok(result);
        }

        [HttpPost, Route("api/bakerOrg/GetIngrediantsCount")]
        public async Task<ActionResult<IEnumerable<IngrediantCountDto>>> GetIngrediantsCout(List<int> recipesId)
        {
            IEnumerable<IngrediantCountDto> result = await _service.GetIngrediantsCout(recipesId);
            return Ok(result);
        }

        [HttpPost, Route("api/bakerOrg/GetRecipeWightAndIngrediantsCount")]
        public async Task<ActionResult<IEnumerable<RecipeWightAndIngrediantCountDto>>> GetRecipeWeightAndIngrediantsCout(List<int> recipesId)
        {
            IEnumerable<RecipeWightAndIngrediantCountDto> result = await _service.GetRecipeWeightAndIngrediantsCout(recipesId);
            return Ok(result);
        }
    }
}
