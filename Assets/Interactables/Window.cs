using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
{
	private void Awake()
	{
	}

	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(Open, "open"),
		new Tuple<Action, string>(Break, "break"),
		new Tuple<Action, string>(null, "exit")
	};

	private void Break()
	{
		ProgressController.Instance.ChangeInsanity(100);
	}

	private void Open()
	{
		ProgressController.Instance.ChangeInsanity(-100);
	}
}
	