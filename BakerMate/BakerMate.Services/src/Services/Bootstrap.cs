/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.BakerOrg;
using BakerMate.Services.Ingrediant;
using BakerMate.Services.Recipe;

namespace BakerMate.Services
{
    public static class Bootstrap
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBakerOrgServices(configuration);
            services.AddRecipeServices(configuration);
            services.AddIngrediantServices(configuration);
            return services;
        }
    }
}
