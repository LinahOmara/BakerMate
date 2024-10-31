// See https://aka.ms/new-console-template for more information
using BakerMate.DbContext.Presistance;
using BakerMate.Domain.Model;
using BakerMate.Services.Recipes;
using BakerMate.Services.src.Services.Calculator;
using Microsoft.EntityFrameworkCore;

var appcontext = new AppDbContextFactory();
var dbcontext = appcontext.CreateDbContext();
var recipesize1 = dbcontext.Set<RecipeSize>().Include(x => x.Recipe).ThenInclude(x=>x.RecipeIngredients)
    .ThenInclude(x => x.Ingredient).SingleOrDefault(x => x.Id == 2);
var recipesize2 = dbcontext.Set<RecipeSize>().Include(x => x.Recipe).ThenInclude(x => x.RecipeIngredients).
    ThenInclude(x => x.Ingredient).SingleOrDefault(x => x.Id == 3);
var recipesize3 = dbcontext.Set<RecipeSize>().Include(x => x.Recipe).ThenInclude(x => x.RecipeIngredients)
    .ThenInclude(x => x.Ingredient).SingleOrDefault(x => x.Id == 2);
var recipesizes = new Dictionary<RecipeSize,int>();
recipesizes.Add(recipesize1,2);
recipesizes.Add(recipesize2,5);
var calculator = new Calculator();
var output = calculator.CalculateByRecipes(recipesizes);
foreach (var item in output.Result)
{
    Console.WriteLine(item.Key.Name + " :  " + item.Value);
}

