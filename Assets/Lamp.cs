using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
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

    public void Interact()
    {
        _state = !_state;
        _enabledVisual.SetActive(_state);
        if (_enabledPills != null)
            _enabledPills.SetActive(_state);
    }
}