/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BakerMate.Services.Recipe
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddRecipeServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IRecipeAmountService, RecipeAmountService>();
            return services;
        }
    }
}
