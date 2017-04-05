using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace Foodyism.Core.Global
{
	public interface IIngredientsDataService
	{
		Task<DataResult<List<IIngredient>>> GetIngredientSuggestions(string autocomplete);
	}
}
