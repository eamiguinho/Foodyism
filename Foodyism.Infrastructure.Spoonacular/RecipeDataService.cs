using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class RecipeDataService : IRecipeDataService
	{
		public async Task<DataResult<IRecipe>> GetRecipeDetailsById(IRecipe recipe)
		{
			if (recipe == null) return new DataResult<IRecipe>(Result.Error);
			var res = await RestHelper<FullRecipeDto>.GetAsync(string.Format("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/{0}/information?includeNutrition=false", recipe.Id));
			if (res.IsSuccessful)
			{
				return new DataResult<IRecipe>(RecipeDtoFactory.CreateFull(res.Body, recipe));
			}
			else if (res.Code == System.Net.HttpStatusCode.Unauthorized)
			{
				return new DataResult<IRecipe>(Result.Unauthorized);
			}
			else
			{
				return new DataResult<IRecipe>(Result.Error);
			}
		}

		public async Task<DataResult<List<IRecipe>>> GetRecipesByIngredients(List<IIngredient> ingredients)
		{
			if (ingredients == null || ingredients.Count == 0) return new DataResult<List<IRecipe>>(Result.Error);
			var res = await RestHelper<List<RecipeDto>>.GetAsync(string.Format("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/recipes/findByIngredients?fillIngredients=true&ingredients={0}&limitLicense=false&number=5&ranking=1", string.Join(",", ingredients.Select(x => x.Name).ToList())));
			if (res.IsSuccessful)
			{
				return new DataResult<List<IRecipe>>(res.Body.Select(RecipeDtoFactory.Create).ToList());
			}
			else if (res.Code == System.Net.HttpStatusCode.Unauthorized)
			{
				return new DataResult<List<IRecipe>>(Result.Unauthorized);
			}
			else
			{
				return new DataResult<List<IRecipe>>(Result.Error);
			}
		}
	}
}
