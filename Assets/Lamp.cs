using System;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GameObject _enabledVisual;
    [SerializeField]
    private GameObject _enabledPills;
    private bool _state;
    [SerializeField] 
    private Transform _menuTransform;

    private void Awake()
    {
        _enabledVisual.SetActive(false);
        if (_enabledPills != null)
            _enabledPills.SetActive(false);
    }

    public Transform MenuTransform => _menuTransform;
    public List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
    {
        new Tuple<Action, string>(Switch, "turn on/off"),
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