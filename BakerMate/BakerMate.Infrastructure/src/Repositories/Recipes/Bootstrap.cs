/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Recipes;

namespace BakerMate.Repositories.Recipes
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddRecipesRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRecipeAmountRepository, RecipeAmountRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            return services;
       }
    }
}
