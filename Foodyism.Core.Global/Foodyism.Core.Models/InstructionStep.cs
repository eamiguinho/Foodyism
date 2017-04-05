using System;
using System.Collections.Generic;
using Foodyism.Core.Global;

namespace Foodyism.Core.Models
{
	public class InstructionStep : IInstructionStep
	{
		public string Description { get; set; }

		public List<IEquipment> Equipment { get; set; }
	
		public int Number { get; set; }
	}
}
