/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Ingredients;

namespace BakerMate.Repositories.Ingredients
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddIngredientsRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            return services;
       }
    }
}
