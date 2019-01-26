using UnityEngine;

public class InteractionController : Singletone<InteractionController>
{
    private IHighlightable _lastHighlightable;
    [SerializeField] 
    private Texture2D _highlightCursorTexture;

    private bool _interactionEnabled = true;

    public bool InteractionEnabled
    {
        set
        {
            if (!value)
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            _interactionEnabled = value;
        }
    }
    
    private void Update()
    {
        if (!_interactionEnabled)
            return;
        var transformUnderCoursor = Camera.main.GetTransformUnderCoursor2D();
        var highlightable = transformUnderCoursor?.GetComponent<IHighlightable>();
        if (highlightable != null)
        {
            highlightable.Highlight();
            _lastHighlightable = highlightable;
            UpdateCursor(true);
            CheckInteraction(transformUnderCoursor);
        }
        else
        {
            UpdateCursor(false);
            if (_lastHighlightable != null)
            {
                _lastHighlightable.CancelHighlight();
                _lastHighlightable = null;
            }
        }
    }

    private void CheckInteraction(Transform highlightedTransform)
    {
        if (!Input.GetMouseButtonDown(0)) 
            return;
        highlightedTransform.GetComponent<IInteractable>()?.Interact();
    }

    private void UpdateCursor(bool highlighted)
    {
        Cursor.SetCursor(highlighted ? _highlightCursorTexture : null, new Vector2(13, 16), CursorMode.ForceSoftware);
    }
}