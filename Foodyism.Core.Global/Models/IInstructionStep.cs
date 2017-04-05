using System;
using System.Collections.Generic;

namespace Foodyism.Core.Global
{

	public interface IInstructionStep
	{
		string Description { get; set; }
		List<IEquipment> Equipment { get; set; }
		int Number { get; set; }
	}
}
