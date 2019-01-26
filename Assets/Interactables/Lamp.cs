using System;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interactable
{
    [SerializeField]
    private GameObject _enabledVisual;
    [SerializeField]
    private GameObject _enabledPills;
    private bool _state;

    private void Awake()
    {
        _enabledVisual.SetActive(false);
        if (_enabledPills != null)
            _enabledPills.SetActive(false);
    }

    public override List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
    {
        new Tuple<Action, string>(Switch, "remove"),
        new Tuple<Action, string>(null, "exit")
    };

    private void Switch()
    {
        _state = !_state;
        _enabledVisual.SetActive(_state);
        if (_enabledPills != null)
            _enabledPills.SetActive(_state);
    }
}