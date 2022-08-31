/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Repositories.BakerOrg;
using BakerMate.Repositories.Ingrediant;
using BakerMate.Repositories.Recipe;

namespace BakerMate.Repositories
{
    public static class Bootstrap
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBakerOrgRepositories(configuration);
            services.AddRecipeRepositories(configuration);
            services.AddIngrediantRepositories(configuration);
            return services;
        }
    }
}
