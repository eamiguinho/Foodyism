using NUnit.Framework;
using Foodyism.Core.Models;
using Foodyism.Core.Global;
using Autofac;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Foodyism.Infrastructure.Spoonacular.Tests
{
	[TestFixture]
	public class RecipeDataServiceTest
	{
		[SetUp]
		public void Init()
		{
			ModelsIoCRegister.Register();
			SpoonacularIoCRegister.Register();
		}

		[Test]
		public async Task GetRecipesByIngredients_ParamMissing()
		{
			var service = IoC.Container.Resolve<IRecipeDataService>();
			var res = await service.GetRecipesByIngredients(null);
			Assert.AreEqual(Result.Error, res.Result);
			res = await service.GetRecipesByIngredients(new List<IIngredient>());
			Assert.AreEqual(Result.Error, res.Result);
		}

		[Test]
		public async Task GetRecipesByIngredients_Ok()
		{
			var listIngredients = new List<IIngredient>();
			listIngredients.Add(new Ingredient { Name = "Chicken" });
			listIngredients.Add(new Ingredient { Name = "Rice" });
			var service = IoC.Container.Resolve<IRecipeDataService>();
			var res = await service.GetRecipesByIngredients(listIngredients);
			Assert.AreEqual(Result.Ok, res.Result);
			Assert.IsNotNull(res.Data);
		}	

		[Test]
		public async Task GetRecipesDetailsById_ParamMissing()
		{
			var service = IoC.Container.Resolve<IRecipeDataService>();
			var res = await service.GetRecipeDetailsById(null);
			Assert.AreEqual(Result.Error, res.Result);

		}

		[Test]
		public async Task GetRecipesDetailsById_Ok()
		{
			var service = IoC.Container.Resolve<IRecipeDataService>();
			var recipe = IoC.Container.Resolve<IRecipe>();
			recipe.Id = 479101;
			var res = await service.GetRecipeDetailsById(recipe);
			Assert.AreEqual(Result.Ok, res.Result);
			Assert.IsNotNull(res.Data);
		}	
	}
}
