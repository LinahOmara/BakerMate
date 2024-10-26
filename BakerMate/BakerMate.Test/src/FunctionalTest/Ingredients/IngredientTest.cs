/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Ingredients;
using Xunit;
using Xunit.Abstractions;

namespace BakerMate.FunctionalTest.Ingredients
{
    public class IngredientServiceTest : IDisposable, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;
        private readonly IServiceScope _scope;
        private readonly IIngredientService _service;

        internal IngredientServiceTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _output = output;
            _scope = factory.Services.CreateScope();
            _service = _scope.ServiceProvider.GetService<IIngredientService>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }

        [Theory]
        [MemberData(nameof(Create_Data))]
        public async Task Create(IngredientDto newIngredient)
        {
            // Act
            int result = await _service.Create(newIngredient);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Create_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(Update_Data))]
        public async Task Update(int id, IngredientDto newIngredient)
        {
            // Act
            int result = await _service.Update(id, newIngredient);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Update_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Theory]
        [MemberData(nameof(Delete_Data))]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        public static IEnumerable<object[]> Delete_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Fact]
        public async Task Get()
        {
            // Act
            IEnumerable<IngredientDto> result = await _service.Get();

            // Assert
            Assert.NotNull(result);
        }
    }
}
