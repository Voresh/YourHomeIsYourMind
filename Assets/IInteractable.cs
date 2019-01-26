using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    Transform MenuTransform { get; }

    List<Tuple<Action, string>> Actions { get; }
}