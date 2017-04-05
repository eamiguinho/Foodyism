using System;
using System.Collections.Generic;
using System.Linq;
using Foodyism.Core.Global;

namespace Foodyism.Core.Models
{
	public class Recipe : IRecipe
	{
		public string Description { get; set; }

		public int Id { get; set; }

		public string Image { get; set; } 

		public List<IIngredient> Ingredients { get; set; }

		public string Title { get; set; }

		public int MissingIngredientsCount 
		{
			get
			{
				if (Ingredients == null || Ingredients.Count == 0) return 0;
				return Ingredients.Count(x => x.IsMissing);
			}
		}

		public int UsedIngredientsCount
		{
			get
			{
				if (Ingredients == null || Ingredients.Count == 0) return 0;
				return Ingredients.Count(x => !x.IsMissing);
			}
		}

		public string SimpleInstructions { get; set; }

		public List<IDetailedInstruction> DetailedInstructions { get; set; }

		public int ReadyInMinutes { get; set; }

		public int Servings { get; set; }

		public double HealthScore { get; set; }
	}
}
