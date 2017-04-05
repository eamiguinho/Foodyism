using System;
using System.Collections.Generic;

namespace Foodyism.Core.Global
{
	public interface IRecipe
	{
		int Id { get; set; }
		string Title { get; set; }
		List<IIngredient> Ingredients { get; set; }
		string Description { get; set; }
		string Image { get; set; }
		int MissingIngredientsCount { get; }
		int UsedIngredientsCount { get; }

		string SimpleInstructions { get; set; }
		List<IDetailedInstruction> DetailedInstructions { get; set; }
		int ReadyInMinutes { get; set; }
		int Servings { get; set; }
		double HealthScore { get; set; }
	}
}
