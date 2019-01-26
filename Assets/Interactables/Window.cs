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
		new Tuple<Action, string>(null, "open"),
		new Tuple<Action, string>(null, "break"),
		new Tuple<Action, string>(null, "exit")
	};
}
	