/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakerMate.Services.BakerOrg
{
    public interface IBakerOrgRepository
    {
        Task<IEnumerable<RecipeWightDto>> GetWightPerRecipe(List<int> recipesId);

        Task<IEnumerable<IngrediantCountDto>> GetIngrediantsCout(List<int> recipesId);

        Task<IEnumerable<RecipeWightAndIngrediantCountDto>> GetRecipeWeightAndIngrediantsCout(List<int> recipesId);
    }
}
