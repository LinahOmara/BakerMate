/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Abrar.BakerOrg
{
    internal static class OpenAPI
    {
        internal static IServiceCollection AddOpenApi(this IServiceCollection services, IConfiguration configuration)
        {
            var config = ReadConfig(configuration);
            services.AddSwaggerGen(c =>
            {
                // Set the comments path for the Swagger JSON and UI.
                DirectoryInfo dir = new DirectoryInfo(AppContext.BaseDirectory);
                string name = Assembly.GetExecutingAssembly().GetName().Name;
                string pattern = $"{name}*.xml";
                foreach (var fi in dir.GetFiles(pattern, SearchOption.TopDirectoryOnly))
                {
                    c.IncludeXmlComments(fi.FullName, true);
                }

                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddCustomDocumentFilter(config.FilterPattern);

                var contact = new OpenApiContact()
                {
                    Email = config.Contact.Email,
                    Name = config.Contact.Name,
                    Url = config.Contact.URL != null? new Uri(config.Contact.URL) : null
                };

                foreach (var documentConfig in config.OpenAPIDocumentsConfigurations)
                {
                    c.SwaggerDoc(
                        documentConfig.Name,
                        new OpenApiInfo()
                        {
                            Title = $"{name}: {documentConfig.Title}",
                            Version = documentConfig.Version,
                            Description = documentConfig.DocumentDescription,
                            Contact = contact
                        }
                    );
                }
            });

            return services;
        }

        internal static IApplicationBuilder UseOpenApi(this IApplicationBuilder app, IConfiguration configuration)
        {
            var config = ReadConfig(configuration);
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                foreach (var documentConfig in config.OpenAPIDocumentsConfigurations)
                {
                    c.SwaggerEndpoint(
                        $"./{documentConfig.Name}/swagger.json", //Path of json documentation to populate the UI
                        documentConfig.Title);

                    // enable html tag links
                    c.EnableDeepLinking();

                    // display ids that are used for link tagging
                    if (documentConfig.ShowOperationId)
                    {
                        c.DisplayOperationId();
                    }
                }
            });

            // redirect empty url to swagger UI
            app.UseRewriter(new RewriteOptions().AddRedirect("^$|index.html", "swagger/index.html"));

            return app;
        }

        internal static SwaggerGenOptions AddCustomDocumentFilter(this SwaggerGenOptions c, string pattern)
        {
            if (pattern != null)
            {
                Regex rx = new Regex(pattern, RegexOptions.Compiled);
                c.CustomSchemaIds(t =>
                {
                    string fullName = t.FullName;
                    return rx.IsMatch(fullName) ? CustomDocumentFilter.IGNORE_PREFIX + fullName : t.Name;
                });
                c.DocumentFilter<CustomDocumentFilter>();
            }
            return c;
        }

        private static OpenAPIConfigurations ReadConfig(IConfiguration configuration)
        {
            OpenAPIConfigurations config = new OpenAPIConfigurations();
            configuration.Bind("OpenAPI", config);
            return config;
        }
    }

    internal class OpenAPIConfigurations
    {
        public OpenAPIConfigurations()
        {
            Contact = new OpenAPIContactConfigurations();
            OpenAPIDocumentsConfigurations = new List<OpenAPIDocumentConfigurations>();
        }

        public OpenAPIContactConfigurations Contact { get; set; }
        public List<OpenAPIDocumentConfigurations> OpenAPIDocumentsConfigurations { get; set; }
        public string FilterPattern { get; set; }
    }

    internal class OpenAPIDocumentConfigurations
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public string DocumentDescription { get; set; }
        public bool ShowOperationId { get; set; }
    }

    internal class OpenAPIContactConfigurations
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string Email { get; set; }
    }

    internal class CustomDocumentFilter : IDocumentFilter
    {
        internal const string IGNORE_PREFIX = "IGNORE::";

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var schemas = swaggerDoc.Components.Schemas;
            foreach (var schema in schemas)
            {
                if (schema.Key.StartsWith(IGNORE_PREFIX))
                {
                    schemas.Remove(schema.Key);
                }
                else
                {
                    var properties = schema.Value.Properties;
                    foreach (var property in properties)
                    {
                        var p = property.Value;
                        if (p.Items?.Reference?.Id.StartsWith(IGNORE_PREFIX) == true
                            || p.AllOf?.Any(e => e.Reference.Id.StartsWith(IGNORE_PREFIX)) == true
                            || p.AnyOf?.Any(e => e.Reference.Id.StartsWith(IGNORE_PREFIX)) == true)
                        {
                            properties.Remove(property.Key);
                        }
                    }
                }
            }
        }
    }
}
