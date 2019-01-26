using UnityEngine;

public class ScaleHighlight : MonoBehaviour, IHighlightable
{
	[SerializeField]
	private float _factor = 1.03f;
	
	public void Highlight()
	{
		transform.localScale = Vector3.one * _factor;
	}

	public void CancelHighlight()
	{
		transform.localScale = Vector3.one;
	}
}