/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BakerMate.FunctionalTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
        }
    }
}
