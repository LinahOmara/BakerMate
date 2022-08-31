/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;

namespace BakerMate.Services.Ingrediant
{
    public interface IIngrediantService
    {
        Task<int> Create(IngrediantDto newIngrediant);

        Task<int> Update(int ingrediantId, IngrediantDto newIngrediant);

        Task<int> Delete();

        Task<int> Get(IngrediantDto newIngrediant);
    }
}
