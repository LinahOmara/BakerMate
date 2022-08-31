/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Recipe;

namespace BakerMate.Repositories.Recipe
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddRecipeRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRecipeAmountRepository, RecipeAmountRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            return services;
       }
    }
}
