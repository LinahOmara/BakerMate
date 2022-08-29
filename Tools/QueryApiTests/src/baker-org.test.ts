/*
 * Copyright (c) 2020-present RaisaEnergy. All Rights Reserved.
 *
 * Licensed Material - Property of RaisaEnergy.
 */

import { app, module, service, operation } from './util'

app('baker-org', async ctx => {

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
})
