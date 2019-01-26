using UnityEngine;

public class OutlineHighlight : MonoBehaviour, IHighlightable
{
    [SerializeField]
    private GameObject _outline;

    private void Awake()
    {
        CancelHighlight();
    }

    public void Highlight()
    {
        if (_outline != null)
            _outline.SetActive(true);
    }

    public void CancelHighlight()
    {
        if (_outline != null)
            _outline.SetActive(false);
    }
}