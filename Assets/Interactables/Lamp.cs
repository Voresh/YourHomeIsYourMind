using System;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
    {
        new Tuple<Action, string>(TurnOff, "turn off"),
        new Tuple<Action, string>(null, "exit")
    };

    private void TurnOff()
    {
        ProgressController.Instance.ChangeInsanity(-100);
    }
}