using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionController : Singletone<InteractionController>
{
    private IHighlightable _lastHighlightable;
    [SerializeField] 
    private Texture2D _highlightCursorTexture;
    [SerializeField] 
    private GameObject _interactionWidget;
    [SerializeField] 
    private GameObject _actionButtonPrefab;

    private bool _interactionEnabled = true;
    private Camera _camera;
    
    public bool InteractionEnabled
    {
        set
        {
            if (!value)
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            _interactionEnabled = value;
        }
    }

    private void Start()
    {
        _interactionWidget.SetActive(false);
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!_interactionEnabled)
            return;
        var transformUnderCoursor = _camera.GetTransformUnderCoursor2D();
        var highlightable = transformUnderCoursor?.GetComponent<IHighlightable>();
        if (highlightable != null)
        {
            if (_lastHighlightable != null)
                _lastHighlightable.CancelHighlight();
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
        
        var interactable = highlightedTransform.GetComponent<Interactable>();
        
        var menuTransform = interactable?.MenuTransform;
        if (menuTransform == null)
            return;
        
        foreach (Transform child in _interactionWidget.transform) {
            Destroy(child.gameObject);
        }
        foreach (var action in interactable.Actions)
        {
            var button = Instantiate(_actionButtonPrefab, _interactionWidget.transform);
            button.GetComponentInChildren<Button>(true).onClick.AddListener(() =>
            {
                action.Item1?.Invoke();
                _interactionWidget.SetActive(false);
                InteractionEnabled = true;
            });
            button.GetComponentInChildren<TextMeshProUGUI>(true).text = action.Item2;
        }
        WorldUIController.Instance.MoveToWorldTransform(menuTransform, _interactionWidget.GetComponent<RectTransform>());
        _interactionWidget.SetActive(true);
        InteractionEnabled = false;
    }

    private void UpdateCursor(bool highlighted)
    {
        Cursor.SetCursor(highlighted ? _highlightCursorTexture : null, new Vector2(13, 16), CursorMode.ForceSoftware);
    }
}