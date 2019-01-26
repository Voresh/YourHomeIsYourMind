using System;
using System.Collections.Generic;

public class Cat : Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Stroke, "stroke"),
		new Tuple<Action, string>(null, "pull the tail"),
		new Tuple<Action, string>(null, "exit")
	};

	private void Stroke()
	{
		ProgressController.Instance.ChangeInsanity(200);
	}
}