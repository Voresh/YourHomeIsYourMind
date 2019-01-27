using System;
using System.Collections.Generic;
using UnityEngine;

public class Ficus : Interactable
{
	[SerializeField] 
	private Transform _dropPosition;

	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Water, "water"),
		new Tuple<Action, string>(Remove, "remove"),
		new Tuple<Action, string>(null, "exit")
	};

	private void Remove()
	{
		ProgressController.Instance.ChangeInsanity(-100);
		PillsCreator.CreateAD(_dropPosition);
	}

	private void Water()
	{
		ProgressController.Instance.ChangeInsanity(100);
	}
}