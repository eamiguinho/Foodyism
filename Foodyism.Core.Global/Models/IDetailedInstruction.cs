using System;
using System.Collections.Generic;

namespace Foodyism.Core.Global
{
	public interface IDetailedInstruction
	{
		List<IInstructionStep> Steps { get; set; }

		string Name { get; set; }
	}
}
