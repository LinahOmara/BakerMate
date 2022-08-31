/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.BakerOrg;
using BakerMate.Services.Ingredients;
using BakerMate.Services.Recipes;

namespace BakerMate.Services
{
    public static class Bootstrap
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBakerOrgServices(configuration);
            services.AddRecipesServices(configuration);
            services.AddIngredientsServices(configuration);
            return services;
        }
    }
}
