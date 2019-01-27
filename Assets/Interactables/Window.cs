using System;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
{
	[SerializeField]
	private Transform _dropPosition;
	[SerializeField] 
	private SpriteRenderer _spriteRendereer;
	[SerializeField] 
	private Sprite _opened;
	[SerializeField] 
	private Sprite _broken;

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
		PillsCreator.CreateAD(_dropPosition);
		_spriteRendereer.sprite = _broken;
	}

	private void Open()
	{
		ProgressController.Instance.ChangeInsanity(-100);
		_spriteRendereer.sprite = _opened;
	}
}
	