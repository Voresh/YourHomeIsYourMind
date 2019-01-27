using System;
using System.Collections.Generic;
using UnityEngine;

public class Wine : Interactable
{
	[SerializeField]
	private Transform _dropPosition;

	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Break, "break"),
		new Tuple<Action, string>(Drink, "drink"),
		new Tuple<Action, string>(null, "exit"),
	};

	private void Drink()
	{
		ProgressController.Instance.ChangeInsanity(+50);
	}

	private void Break()
	{
		ProgressController.Instance.ChangeInsanity(+100);
		PillsCreator.CreateAD(_dropPosition);
	}
}