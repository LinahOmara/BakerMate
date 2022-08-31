/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BakerMate.Services.Ingredients
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddIngredientsServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIngredientService, IngredientService>();
            return services;
        }
    }
}
