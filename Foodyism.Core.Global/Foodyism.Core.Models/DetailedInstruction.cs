using System;
using System.Collections.Generic;
using Foodyism.Core.Global;

namespace Foodyism.Core.Models
{
	public class DetailedInstruction : IDetailedInstruction
	{
		public string Name { get; set; }

		public List<IInstructionStep> Steps { get; set; }
	}
}
