using System;
using System.Linq;
using Autofac;
using Foodyism.Core.Global;

namespace Foodyism.Infrastructure.Spoonacular
{
	public class AnalyzedInstructionDtoFactory
	{
		internal static IDetailedInstruction Create(AnalyzedInstructionDto dto)
		{
			var detailedInstruction = IoC.Container.Resolve<IDetailedInstruction>();
			detailedInstruction.Name = dto.Name;
			detailedInstruction.Steps = dto.Steps.Select(StepDtoFactory.Create).ToList();
			return detailedInstruction;
		}
	}
}