/*
 * Copyright (c) 2019-present RaisaEnergy. All Rights Reserved.
 * 
 * Licensed Material - Property of RaisaEnergy.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Abrar.BakerOrg.Services.BakerOrg;
using Xunit;
using Xunit.Abstractions;

namespace Abrar.BakerOrg.FunctionalTest.BakerOrg
{
    public class BakerOrgServiceTest : IDisposable, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;
        private readonly IServiceScope _scope;
        private readonly IBakerOrgService _service;

        internal BakerOrgServiceTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _output = output;
            _scope = factory.Services.CreateScope();
            _service = _scope.ServiceProvider.GetService<IBakerOrgService>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }

        [Theory]
        [MemberData(nameof(GetWightPerRecipe_Data))]
        public async Task GetWightPerRecipe(List<int> recipesId)
        {
            // Act
            IEnumerable<RecipeWightDto> result = await _service.GetWightPerRecipe(recipesId);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> GetWightPerRecipe_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(GetIngrediantsCout_Data))]
        public async Task GetIngrediantsCout(List<int> recipesId)
        {
            // Act
            IEnumerable<IngrediantCountDto> result = await _service.GetIngrediantsCout(recipesId);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> GetIngrediantsCout_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(GetRecipeWeightAndIngrediantsCout_Data))]
        public async Task GetRecipeWeightAndIngrediantsCout(List<int> recipesId)
        {
            // Act
            IEnumerable<RecipeWightAndIngrediantCountDto> result = await _service.GetRecipeWeightAndIngrediantsCout(recipesId);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> GetRecipeWeightAndIngrediantsCout_Data =>
            new List<object[]>
            {
                new object[] { },
            };
    }
}
