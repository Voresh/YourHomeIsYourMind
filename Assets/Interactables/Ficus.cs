using System;
using System.Collections.Generic;

public class Ficus : Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Water, "water"),
		new Tuple<Action, string>(Remove, "remove"),
		new Tuple<Action, string>(null, "exit")
	};

	private void Remove()
	{
		ProgressController.Instance.ChangeInsanity(-100);
	}

	private void Water()
	{
		ProgressController.Instance.ChangeInsanity(100);
	}
}