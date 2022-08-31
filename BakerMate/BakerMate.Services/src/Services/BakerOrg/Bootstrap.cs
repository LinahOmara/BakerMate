/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BakerMate.Services.BakerOrg
{
    internal static class Bootstrap
    {
        internal static IServiceCollection AddBakerOrgServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBakerOrgService, BakerOrgService>();
            return services;
        }
    }
}
