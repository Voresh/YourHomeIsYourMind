using System;
using System.Collections.Generic;

public class Ficus : Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(null, "water"),
		new Tuple<Action, string>(null, "remove"),
		new Tuple<Action, string>(null, "exit")
	};
}