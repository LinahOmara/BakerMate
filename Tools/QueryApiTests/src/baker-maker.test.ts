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

  module(ctx, 'recipes', ctx => {

    service(ctx, 'recipe', ctx => {
      operation(ctx, 'Create', '/api/recipes', [
        { _query: { newRecipe: 'RecipeDto' }  }
      ])
      operation(ctx, 'CreateRecipeSize', '/api/recipes/size', [
        { _query: { newRecipeSize: 'RecipeSizeDto' }  }
      ])
      operation(ctx, 'AddIngredientToRecipe', '/api/recipes/{id}/ingredient', [
        { _query: { recipeIngredient: 'RecipeIngredientDto' }  }
      ])
      operation(ctx, 'DeleteIngredientFromRecipe', '/api/recipes/{id}/ingrediant', [
        { id: 0, _query: { ingredientId: 0 }  }
      ])
      operation(ctx, 'Get', '/api/recipes/{id}', [
        { _query: { recipeId: 0 }  }
      ])
      operation(ctx, 'GetNames', '/api/recipes/name')
    })
  })

  module(ctx, 'Ingredients', ctx => {

    service(ctx, 'ingredient', ctx => {
      operation(ctx, 'Create', '/api/Ingredients', [
        { _query: { newIngredient: 'IngredientDto' }  }
      ])
      operation(ctx, 'Update', '/api/Ingredients/{id}', [
        { id: 0, _query: { newIngredient: 'IngredientDto' }  }
      ])
      operation(ctx, 'Delete', '/api/Ingredients', [
        { _query: { id: 0 }  }
      ])
      operation(ctx, 'Get', '/api/Ingredients')
    })
  })
})
