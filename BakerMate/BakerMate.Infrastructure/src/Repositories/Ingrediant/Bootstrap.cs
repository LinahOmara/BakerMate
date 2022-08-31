/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Ingrediant;

namespace BakerMate.Repositories.Ingrediant
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddIngrediantRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIngrediantRepository, IngrediantRepository>();
            return services;
       }
    }
}
