using System;
using System.Collections.Generic;

public class Door : Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Knock, "knock"),
		new Tuple<Action, string>(null, "exit"),
	};

	private void Knock()
	{
		ProgressController.Instance.ChangeInsanity(-200);
	}
}