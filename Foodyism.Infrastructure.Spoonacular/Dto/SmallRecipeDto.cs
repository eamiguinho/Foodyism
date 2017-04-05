using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class RecipeDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Image { get; set; }
		public string ImageType { get; set; }
		public int UsedIngredientCount { get; set; }
		public int MissedIngredientCount { get; set; }
		public List<IngredientDto> MissedIngredients { get; set; }
		public List<IngredientDto> UsedIngredients { get; set; }
		public int Likes { get; set; }
	}

	public class FullRecipeDto : RecipeDto
	{
		public bool Vegetarian { get; set; }
		public bool Vegan { get; set; }
		public bool GlutenFree { get; set; }
		public bool DairyFree { get; set; }
		public bool VeryHealthy { get; set; }
		public bool Cheap { get; set; }
		public bool VeryPopular { get; set; }
		public bool Sustainable { get; set; }
		public int WeightWatcherSmartPoints { get; set; }
		public string Gaps { get; set; }
		public bool LowFodmap { get; set; }
		public bool Ketogenic { get; set; }
		public bool Whole30 { get; set; }
		public int Servings { get; set; }
		public int PreparationMinutes { get; set; }
		public int CookingMinutes { get; set; }
		public string SourceUrl { get; set; }
		public string SpoonacularSourceUrl { get; set; }
		public int AggregateLikes { get; set; }
		public double SpoonacularScore { get; set; }
		public double HealthScore { get; set; }
		public string CreditText { get; set; }
		public string SourceName { get; set; }
		public double PricePerServing { get; set; }
		public List<IngredientDto> ExtendedIngredients { get; set; }
		public int ReadyInMinutes { get; set; }
		public List<object> Cuisines { get; set; }
		public List<string> DishTypes { get; set; }
		public string Instructions { get; set; }
		public List<AnalyzedInstructionDto> AnalyzedInstructions { get; set; }
	}

	public class AnalyzedInstructionDto
	{
		public string Name { get; set; }
		public List<StepDto> Steps { get; set; }
	}

	public class StepDto
	{
		public int Number { get; set; }
		public string Step { get; set; }
		public List<IngredientDto> Ingredients { get; set; }
		public List<EquipmentDto> Equipment { get; set; }
	}

	public class EquipmentDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Image { get; set; }
	}

	public class RecipeDtoFactory
	{
		public static IRecipe Create(RecipeDto dto)
		{
			var recipe = IoC.Container.Resolve<IRecipe>();
			recipe.Title = dto.Title;
			recipe.Image = dto.Image;
			recipe.Ingredients = new List<IIngredient>();
			if (dto.MissedIngredients != null) { 
				foreach (var ing in dto.MissedIngredients)
				{
					var ingredient = IoC.Container.Resolve<IIngredient>();
					ingredient.Name = ing.Name;
					ingredient.IsMissing = true;
					recipe.Ingredients.Add(ingredient);
				}
			}
			if (dto.UsedIngredients != null)
			{
				foreach (var ing in dto.UsedIngredients)
				{
					var ingredient = IoC.Container.Resolve<IIngredient>();
					ingredient.Name = ing.Name;
					ingredient.IsMissing = false;
					recipe.Ingredients.Add(ingredient);
				}
			}
			return recipe;
		}

		public static IRecipe CreateFull(FullRecipeDto dto, IRecipe baseRecipe)
		{
			var recipe = Create(dto);
			if (baseRecipe.Ingredients != null)
			{
				recipe.Ingredients = baseRecipe.Ingredients;
			}
			else {
				recipe.Ingredients = new List<IIngredient>();
				foreach (var ing in dto.ExtendedIngredients) {
					recipe.Ingredients.Add(IngredientDtoFactory.Create(ing));
				}
			}
			recipe.SimpleInstructions = dto.Instructions;
			recipe.DetailedInstructions = dto.AnalyzedInstructions.Select(AnalyzedInstructionDtoFactory.Create).ToList();
			recipe.ReadyInMinutes = dto.ReadyInMinutes;
			recipe.Servings = dto.Servings;
			recipe.HealthScore = dto.HealthScore;
			return recipe;
		}
	}
}
