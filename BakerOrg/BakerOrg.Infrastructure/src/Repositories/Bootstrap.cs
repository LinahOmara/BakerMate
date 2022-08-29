/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Abrar.BakerOrg.Repositories.BakerOrg;

namespace Abrar.BakerOrg.Repositories
{
    public static class Bootstrap
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBakerOrgRepositories(configuration);
            return services;
        }
    }
}
