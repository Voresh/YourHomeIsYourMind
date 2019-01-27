using System;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Interactable
{
	[SerializeField]
	private Transform _adDropPosition;
	[SerializeField]
	private Transform _tranqDropPosition;

	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Stroke, "stroke"),
		new Tuple<Action, string>(PullTheTail, "pull the tail"),
		new Tuple<Action, string>(null, "exit")
	};

	private void PullTheTail()
	{
		PillsCreator.CreateAD(_adDropPosition);
	}

	private void Stroke()
	{
		ProgressController.Instance.ChangeInsanity(200);
		PillsCreator.CreateTranq(_tranqDropPosition);
	}
}