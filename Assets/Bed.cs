using UnityEngine;

public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField] 
    private Animator _animator;

    public void Interact()
    {
        _animator.Play("interacted");
        ProgressController.Instance.DamageReceived(-1);
    }
}