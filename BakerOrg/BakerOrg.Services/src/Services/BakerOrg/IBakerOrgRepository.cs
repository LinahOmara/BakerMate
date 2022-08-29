/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Abrar.BakerOrg.Services.BakerOrg
{
    public interface IBakerOrgRepository
    {
        Task<IEnumerable<RecipeWightDto>> GetWightPerRecipe(List<int> recipesId);

        Task<IEnumerable<IngrediantCountDto>> GetIngrediantsCout(List<int> recipesId);

        Task<IEnumerable<RecipeWightAndIngrediantCountDto>> GetRecipeWeightAndIngrediantsCout(List<int> recipesId);
    }
}
