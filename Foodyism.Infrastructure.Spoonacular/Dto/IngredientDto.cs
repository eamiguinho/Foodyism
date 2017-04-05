using System;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class IngredientDto
	{
		public int Id { get; set; }
		public double Amount { get; set; }
		public string Unit { get; set; }
		public string UnitLong { get; set; }
		public string UnitShort { get; set; }
		public string Aisle { get; set; }
		public string Name { get; set; }
		public string OriginalString { get; set; }
		public string Image { get; set; }
		public string ExtendedName { get; set; }
	}

	public static class IngredientDtoFactory {
		
		public static IIngredient Create(IngredientDto dto) {
			var ingredient = IoC.Container.Resolve<IIngredient>();
			ingredient.Image = dto.Image;
			ingredient.Name = dto.Name;
			return ingredient;
		}
	}
}
