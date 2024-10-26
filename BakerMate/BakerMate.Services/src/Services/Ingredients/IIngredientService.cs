/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace BakerMate.Services.Ingredients
{
    public interface IIngredientService
    {
        Task<int> Create(IngredientDto newIngredient);

        Task<int> Update(int id, IngredientDto newIngredient);

        Task Delete(int id);

        Task<IEnumerable<IngredientDto>> Get();
    }
}
