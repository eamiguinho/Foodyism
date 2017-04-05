using System;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Core.Models
{
	public class Ingredient : IIngredient
	{
		public string Image { get; set; }

		public bool IsMissing { get; set; }

		public string Name { get; set; }
	}
}
