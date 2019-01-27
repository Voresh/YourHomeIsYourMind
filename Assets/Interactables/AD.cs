using System;
using System.Collections.Generic;

public class AD : Interactable
{
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Take, "take"),
		new Tuple<Action, string>(null, "exit")
	};

	private void Take()
	{
		ProgressController.Instance.ADChanged(1);
		Destroy(gameObject);
	}
}