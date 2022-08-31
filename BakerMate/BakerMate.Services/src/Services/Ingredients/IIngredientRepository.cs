/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using BakerMate.Domain.Model;

namespace BakerMate.Services.Ingredients
{
    public interface IIngredientRepository
    {
        Task<int> Create(Ingredient newIngredient);

        Task<int> Update(Ingredient newIngredient);

        Task Delete(int id);

        Task<IEnumerable<Ingredient>> Get();

        Task<Ingredient> Get(int id);
    }
}
