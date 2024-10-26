namespace BakerMate.Domain.Model
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set;}
    }
}