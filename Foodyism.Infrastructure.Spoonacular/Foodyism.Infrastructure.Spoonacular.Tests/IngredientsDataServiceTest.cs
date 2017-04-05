using NUnit.Framework;
using Foodyism.Core.Models;
using Foodyism.Core.Global;
using Autofac;
using System.Threading.Tasks;

namespace Foodyism.Infrastructure.Spoonacular.Tests
{
	[TestFixture]
	public class IngredientsDataServiceTest
	{
		[SetUp]
		public void Init()
		{
			ModelsIoCRegister.Register();
			SpoonacularIoCRegister.Register();
		}

		[Test]
		public async Task GetIngredientSuggestions_ParamMissing()
		{
			var service = IoC.Container.Resolve<IIngredientsDataService>();
			var res = await service.GetIngredientSuggestions("");
			Assert.AreEqual(Result.Error, res.Result);
		}

		[Test]
		public async Task GetIngredientSuggestions_Ok()
		{
			var service = IoC.Container.Resolve<IIngredientsDataService>();
			var res = await service.GetIngredientSuggestions("Chicken");
			Assert.AreEqual(Result.Ok, res.Result);
			Assert.IsNotNull(res.Data);
		}
	}


}
