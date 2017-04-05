using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Core.Models
{
	public class ModelsIoCRegister
	{
		public static void Register()
		{
			IoC.Builder.RegisterType<Ingredient>().As<IIngredient>();
			IoC.Builder.RegisterType<Recipe>().As<IRecipe>();
			IoC.Builder.RegisterType<DetailedInstruction>().As<IDetailedInstruction>();
			IoC.Builder.RegisterType<Equipment>().As<IEquipment>();
		}	
	}
}
