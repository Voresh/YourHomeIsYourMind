using System;
using System.Collections.Generic;
using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    [SerializeField] 
    private Transform _menuTransform;
    
    public Transform MenuTransform => _menuTransform;
    public List<Tuple<Action, string>> Actions => new List<Tuple<Action, string>>
    {
        new Tuple<Action, string>(Take, "take"),
        new Tuple<Action, string>(null, "exit")
    };

    private void Take()
    {
        ProgressController.Instance.PillCollected();
        Destroy(gameObject);
    }
}