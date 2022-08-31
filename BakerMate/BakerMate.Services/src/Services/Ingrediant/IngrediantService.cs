/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System.Threading.Tasks;

namespace BakerMate.Services.Ingrediant
{
    internal class IngrediantService : ServiceBase, IIngrediantService
    {
        private readonly IIngrediantRepository _repository;

        public IngrediantService(IIngrediantRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Create(IngrediantDto newIngrediant)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Update(int ingrediantId, IngrediantDto newIngrediant)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Delete()
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> Get(IngrediantDto newIngrediant)
        {
            return await _repository.Get(newIngrediant);
        }
    }
}
