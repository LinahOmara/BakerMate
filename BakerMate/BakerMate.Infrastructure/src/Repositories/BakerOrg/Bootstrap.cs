/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.BakerOrg;

namespace BakerMate.Repositories.BakerOrg
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddBakerOrgRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBakerOrgRepository, BakerOrgRepository>();
            return services;
       }
    }
}
