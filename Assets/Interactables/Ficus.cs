using System;
using System.Collections.Generic;
using UnityEngine;

public class Ficus : Interactable
{
	[SerializeField] 
	private Transform _dropPosition;
	[SerializeField] 
	private SpriteRenderer _spriteRendereer;
	[SerializeField] 
	private Sprite _broken;

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
		_spriteRendereer.sprite = _broken;
	}

	private void Water()
	{
		ProgressController.Instance.ChangeInsanity(100);
	}
}