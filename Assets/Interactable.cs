using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable: MonoBehaviour
{
    [SerializeField] 
    private Transform _menuTransform;

    public Transform MenuTransform => _menuTransform;

    public abstract List<Tuple<Action, string>> Actions { get; }
}