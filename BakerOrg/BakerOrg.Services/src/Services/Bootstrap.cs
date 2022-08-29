/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Abrar.BakerOrg.Services.BakerOrg;

namespace Abrar.BakerOrg.Services
{
    public static class Bootstrap
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddBakerOrgServices(configuration);
            return services;
        }
    }
}
