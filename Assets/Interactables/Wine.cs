using System;
using System.Collections.Generic;

public class Wine : Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(null, "break"),
		new Tuple<Action, string>(null, "drink"),
		new Tuple<Action, string>(null, "exit"),
	};
}