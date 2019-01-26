using UnityEngine;
using UnityEngine.UI;

public class WorldUIController: Singletone<WorldUIController>
{
	[SerializeField]
	private CanvasScaler _canvasScaler;
	
	public  void MoveToWorldTransform(Transform worldTransform, RectTransform target)
	{
		var screenPoint = Camera.main.WorldToScreenPoint(worldTransform.position);
		var scaleReference = new Vector2(_canvasScaler.referenceResolution.x / Screen.width, _canvasScaler.referenceResolution.y / Screen.height);
		target.anchoredPosition = Vector2.Scale(screenPoint, scaleReference);
	}
}