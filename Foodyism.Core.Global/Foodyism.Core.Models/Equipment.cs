using System;
using Foodyism.Core.Global;

namespace Foodyism.Core.Models
{
	public class Equipment : IEquipment
	{
		public int Id { get; set; }

		public string Image { get; set; }

		public string Name { get; set; }
	}
}
