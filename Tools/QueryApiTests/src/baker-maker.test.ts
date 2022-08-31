/*
 * Copyright (c) 2020-present RaisaEnergy. All Rights Reserved.
 *
 * Licensed Material - Property of RaisaEnergy.
 */

import { app, module, service, operation } from './util'

app('baker-maker', async ctx => {

  module(ctx, 'baker-org', ctx => {

    service(ctx, 'baker-org', ctx => {
      operation(ctx, 'GetWightPerRecipe', '/api/bakerOrg/getRecipeWight', [
        { _query: { recipesId: 'List<int>' }  }
      ])
      operation(ctx, 'GetIngrediantsCout', '/api/bakerOrg/GetIngrediantsCount', [
        { _query: { recipesId: 'List<int>' }  }
      ])
      operation(ctx, 'GetRecipeWeightAndIngrediantsCout', '/api/bakerOrg/GetRecipeWightAndIngrediantsCount', [
        { _query: { recipesId: 'List<int>' }  }
      ])
    })
  })

  module(ctx, 'recipe', ctx => {

    service(ctx, 'recipe', ctx => {
      operation(ctx, 'Create', '/api/recipe', [
        { _query: { newRecipe: 'RecipeDto' }  }
      ])
      operation(ctx, 'CreateRecipeAmount', '/api/recipe/amount', [
        { _query: { newRecipeAmount: 'RecipeDto' }  }
      ])
      operation(ctx, 'AddIngrediantToRecipe', '/api/recipe/{id}/ingrediant', [
        { id: 0, _query: { ingrediantId: 0 }  }
      ])
      operation(ctx, 'DeleteIngrediantFromRecipe', '/api/recipe/{id}/ingrediant', [
        { id: 0, _query: { ingrediantId: 0 }  }
      ])
      operation(ctx, 'Get', '/api/recipe/{id}', [
        { _query: { recipeId: 0 }  }
      ])
      operation(ctx, 'GetNames', '/api/recipe/name')
    })

    service(ctx, 'recipe-amount', ctx => {
      operation(ctx, 'Create', '/api/recipeAmount', [
        { _query: { newRecipeAmount: 'RecipeAmountDto' }  }
      ])
      operation(ctx, 'GetByRecipeId', '/api/recipe/{id}/amount', [
        { id: 0 }
      ])
      operation(ctx, 'GetRecipeFullName', '/api/recipe/name')
    })
  })

  module(ctx, 'ingrediant', ctx => {

    service(ctx, 'ingrediant', ctx => {
      operation(ctx, 'Create', '/api/ingrediant', [
        { _query: { newIngrediant: 'IngrediantDto' }  }
      ])
      operation(ctx, 'Update', '/api/ingrediant/{id}', [
        { _query: { ingrediantId: 0 , newIngrediant: 'IngrediantDto' }  }
      ])
      operation(ctx, 'Delete', '/api/ingrediant')
      operation(ctx, 'Get', '/api/ingrediant', [
        { _query: { newIngrediant: 'IngrediantDto' }  }
      ])
    })
  })
})
