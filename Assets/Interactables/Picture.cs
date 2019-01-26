using System;
using System.Collections.Generic;

namespace Interactables
{
	public class Picture : Interactable
	{
		public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
		{
			new Tuple<Action, string>(null, "remove"),
			new Tuple<Action, string>(null, "exit"),
		};
	}
}