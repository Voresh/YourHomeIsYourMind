﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Interactables
{
	public class Picture : Interactable
	{
		[SerializeField]
		private Transform _dropPosition;

		public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
		{
			new Tuple<Action, string>(TakeOff, "take off"),
			new Tuple<Action, string>(null, "exit"),
		};

		private void TakeOff()
		{
			ProgressController.Instance.ChangeInsanity(100);
			PillsCreator.CreateAD(_dropPosition);
		}
	}
}