using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class SpoonacularIoCRegister {
		public static void Register() {
			IoC.Builder.RegisterType<IngredientsDataService>().As<IIngredientsDataService>().SingleInstance();
			IoC.Builder.RegisterType<RecipeDataService>().As<IRecipeDataService>().SingleInstance();
		}
	}
}
