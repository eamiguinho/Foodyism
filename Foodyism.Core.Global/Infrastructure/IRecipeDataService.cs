using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodyism.Core.Global
{
	public interface IRecipeDataService
	{
		Task<DataResult<List<IRecipe>>> GetRecipesByIngredients(List<IIngredient> ingredients);

		Task<DataResult<IRecipe>> GetRecipeDetailsById(IRecipe recipe);
	}
}
