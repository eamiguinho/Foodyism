using System;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	class EquipmentDtoFactory
	{
		internal static IEquipment Create(EquipmentDto dto)
		{
			var equipment = IoC.Container.Resolve<IEquipment>();
			equipment.Name = dto.Name;
			equipment.Id = dto.Id;
			equipment.Image = dto.Image;
			return equipment;
		}
	}
}