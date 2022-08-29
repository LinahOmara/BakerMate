/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Abrar.BakerOrg.Services.BakerOrg;

namespace Abrar.BakerOrg.Repositories.BakerOrg
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
