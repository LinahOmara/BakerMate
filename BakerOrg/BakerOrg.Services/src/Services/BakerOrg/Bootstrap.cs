/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Abrar.BakerOrg.Services.BakerOrg
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
