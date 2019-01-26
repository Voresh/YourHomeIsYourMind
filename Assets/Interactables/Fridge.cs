using System;
using System.Collections.Generic;

public class Fridge: Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(null, "open"),
		new Tuple<Action, string>(null, "exit"),
	};
}