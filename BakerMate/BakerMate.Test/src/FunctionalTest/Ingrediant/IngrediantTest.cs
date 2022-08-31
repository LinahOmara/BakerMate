/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BakerMate.Services.Ingrediant;
using Xunit;
using Xunit.Abstractions;

namespace BakerMate.FunctionalTest.Ingrediant
{
    public class IngrediantServiceTest : IDisposable, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;
        private readonly IServiceScope _scope;
        private readonly IIngrediantService _service;

        internal IngrediantServiceTest(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _output = output;
            _scope = factory.Services.CreateScope();
            _service = _scope.ServiceProvider.GetService<IIngrediantService>();
        }

        public void Dispose()
        {
            _scope?.Dispose();
        }

        [Theory]
        [MemberData(nameof(Create_Data))]
        public async Task Create(IngrediantDto newIngrediant)
        {
            // Act
            int result = await _service.Create(newIngrediant);

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
        public async Task Update(int ingrediantId, IngrediantDto newIngrediant)
        {
            // Act
            int result = await _service.Update(ingrediantId, newIngrediant);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Update_Data =>
            new List<object[]>
            {
                new object[] { },
            };

        [Fact]
        public async Task Delete()
        {
            // Act
            int result = await _service.Delete();

            // Assert
            Assert.NotNull(result);
        }

        [Theory]
        [MemberData(nameof(Get_Data))]
        public async Task Get(IngrediantDto newIngrediant)
        {
            // Act
            int result = await _service.Get(newIngrediant);

            // Assert
            Assert.NotNull(result);
        }

        public static IEnumerable<object[]> Get_Data =>
            new List<object[]>
            {
                new object[] { },
            };
    }
}
