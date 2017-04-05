using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class IngredientsDataService : IIngredientsDataService
	{
		public async Task<DataResult<List<IIngredient>>> GetIngredientSuggestions(string autocomplete)
		{
			if (string.IsNullOrEmpty(autocomplete)) return new DataResult<List<IIngredient>>(Result.Error);
			var res = await RestHelper<List<IngredientDto>>.GetAsync(string.Format("https://spoonacular-recipe-food-nutrition-v1.p.mashape.com/food/ingredients/autocomplete?metaInformation=false&number=10&query={0}",autocomplete));
			if (res.IsSuccessful)
			{
				return new DataResult<List<IIngredient>>(res.Body.Select(IngredientDtoFactory.Create).ToList());
			}
			else if (res.Code == System.Net.HttpStatusCode.Unauthorized)
			{
				return new DataResult<List<IIngredient>>(Result.Unauthorized);
			}
			else
			{
				return new DataResult<List<IIngredient>>(Result.Error);
			}
		}
	}


	
}
