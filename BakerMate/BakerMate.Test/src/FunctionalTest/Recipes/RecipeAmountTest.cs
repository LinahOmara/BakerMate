/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Recipes;
using Xunit;
using Xunit.Abstractions;

namespace BakerMate.FunctionalTest.Recipes
{
    public class RecipeAmountServiceTest : IDisposable, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;
        private readonly IServiceScope _scope;
        private readonly IRecipeAmountService _service;

        internal RecipeAmountServiceTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _output = output;
            _scope = factory.Services.CreateScope();
            _service = _scope.ServiceProvider.GetService<IRecipeAmountService>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }

        [Theory]
        [MemberData(nameof(Create_Data))]
        public async Task Create(RecipeAmountDto newRecipeAmount)
        {
            // Act
            int result = await _service.Create(newRecipeAmount);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Create_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(GetByRecipeId_Data))]
        public async Task GetByRecipeId(int id)
        {
            // Act
            RecipeAmountDto result = await _service.GetByRecipeId(id);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> GetByRecipeId_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Fact]
        public async Task GetRecipeFullName()
        {
            // Act
            IEnumerable<RecipeNameDto> result = await _service.GetRecipeFullName();

            // Assert
            Assert.NotNull(result);
        }
    }
}
