using UnityEngine;

public class Pills : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ProgressController.Instance.PillCollected();
        Destroy(gameObject);
    }
}