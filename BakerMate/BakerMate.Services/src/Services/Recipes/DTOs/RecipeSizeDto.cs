/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

using BakerMate.Domain.Model;

namespace BakerMate.Services.Recipes
{
    public class RecipeSizeDto
    {
        public int Id { get; set; }
        public int RecipieId { get; set; }
        public double Multiplier { get; set; }
        public double OutputWeight { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}
