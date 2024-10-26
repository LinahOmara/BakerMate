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
        [MemberData(nameof(CreateRecipeSize_Data))]
        public async Task CreateRecipeSize(RecipeSizeDto newRecipeSize)
        {
            // Act
            int result = await _service.CreateRecipeSize(newRecipeSize);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> CreateRecipeSize_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(AddIngredientToRecipe_Data))]
        public async Task AddIngredientToRecipe(RecipeIngredientDto recipeIngredient)
        {
            // Act
            int result = await _service.AddIngredientToRecipe(recipeIngredient);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> AddIngredientToRecipe_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(DeleteIngredientFromRecipe_Data))]
        public async Task DeleteIngredientFromRecipe(int id, int ingredientId)
        {
            await _service.DeleteIngredientFromRecipe(id, ingredientId);
        }

        public static IEnumerable<object[]> DeleteIngredientFromRecipe_Data =>
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
            IEnumerable<RecipeNameDto> result = await _service.GetNames();

            // Assert
            Assert.NotNull(result);
        }
    }
}
