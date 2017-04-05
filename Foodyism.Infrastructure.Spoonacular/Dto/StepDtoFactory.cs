using System;
using System.Linq;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	class StepDtoFactory
	{
		internal static IInstructionStep Create(StepDto dto)
		{
			var step = IoC.Container.Resolve<IInstructionStep>();
			step.Equipment = dto.Equipment.Select(EquipmentDtoFactory.Create).ToList();
			step.Description = dto.Step;
			step.Number = dto.Number;
			return step;
		}
	}
}