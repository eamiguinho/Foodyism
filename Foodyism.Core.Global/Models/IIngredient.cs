using System;
namespace Foodyism.Core.Global
{
	public interface IIngredient
	{
		string Name { get; set; }
		string Image { get; set; }
		bool IsMissing { get; set; }
	}
}
