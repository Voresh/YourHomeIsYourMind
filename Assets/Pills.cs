using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ProgressController.Instance.ChangeProgress(1);
        Destroy(gameObject);
    }
}