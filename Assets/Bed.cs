using System;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] 
    private Transform _menuTransform;
    [SerializeField] 
    private Animator _animator;

    public Transform MenuTransform => _menuTransform;
    public List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
    {
        new Tuple<Action, string>(Sleep, "sleep"),
        new Tuple<Action, string>(null, "exit")
    };

    private void Sleep()
    {
        _animator.Play("interacted");
        ProgressController.Instance.HealthChanged(-1);
    }
}