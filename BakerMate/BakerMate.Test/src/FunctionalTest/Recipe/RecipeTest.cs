/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Recipe;
using Xunit;
using Xunit.Abstractions;

namespace BakerMate.FunctionalTest.Recipe
{
    public class RecipeServiceTest : IDisposable, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;
        private readonly IServiceScope _scope;
        private readonly IRecipeService _service;

        internal RecipeServiceTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _output = output;
            _scope = factory.Services.CreateScope();
            _service = _scope.ServiceProvider.GetService<IRecipeService>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }

        [Theory]
        [MemberData(nameof(Create_Data))]
        public async Task Create(RecipeDto newRecipe)
        {
            // Act
            int result = await _service.Create(newRecipe);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Create_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(CreateRecipeAmount_Data))]
        public async Task CreateRecipeAmount(RecipeDto newRecipeAmount)
        {
            // Act
            int result = await _service.CreateRecipeAmount(newRecipeAmount);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> CreateRecipeAmount_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(AddIngrediantToRecipe_Data))]
        public async Task AddIngrediantToRecipe(int id, int ingrediantId)
        {
            // Act
            int result = await _service.AddIngrediantToRecipe(id, ingrediantId);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> AddIngrediantToRecipe_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(DeleteIngrediantFromRecipe_Data))]
        public async Task DeleteIngrediantFromRecipe(int id, int ingrediantId)
        {
            // Act
            int result = await _service.DeleteIngrediantFromRecipe(id, ingrediantId);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> DeleteIngrediantFromRecipe_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(Get_Data))]
        public async Task Get(int recipeId)
        {
            // Act
            RecipeDto result = await _service.Get(recipeId);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Get_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Fact]
        public async Task GetNames()
        {
            // Act
            RecipeNameDto result = await _service.GetNames();

            // Assert
            Assert.NotNull(result);
        }
    }
}
