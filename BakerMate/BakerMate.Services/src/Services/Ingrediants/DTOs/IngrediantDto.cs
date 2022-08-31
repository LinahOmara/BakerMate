/*
 * Copyright (c) 2022-present Baker Mate. All Rights Reserved.
 * 
 * Licensed Material - Property of Baker Mate.
 */

namespace BakerMate.Services.Ingrediants
{
    public class IngrediantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string PurchaceLocation { get; set; }
        public int UnitOfMeasureId { get; set; }
    }
}
