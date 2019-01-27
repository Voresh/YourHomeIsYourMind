using System;
using System.Collections.Generic;
using UnityEngine;

public class Fridge: Interactable
{
	[SerializeField] 
	private Transform _dropPosition;
	
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(() => { PillsCreator.CreateAD(_dropPosition); }, "open"),
		new Tuple<Action, string>(null, "exit"),
	};
}