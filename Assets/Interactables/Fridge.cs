using System;
using System.Collections.Generic;
using UnityEngine;

public class Fridge: Interactable
{
	[SerializeField] 
	private Transform _dropPosition;
	[SerializeField] 
	private SpriteRenderer _spriteRendereer;
	[SerializeField] 
	private Sprite _opened;
	
	public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
	{
		new Tuple<Action, string>(() =>
		{
			PillsCreator.CreateAD(_dropPosition);
			_spriteRendereer.sprite = _opened;
		}, "open"),
		new Tuple<Action, string>(null, "exit"),
	};
}