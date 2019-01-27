using UnityEngine;

public class ScaleHighlight : MonoBehaviour, IHighlightable
{
	[SerializeField]
	private float _factor = 1.03f;
	[SerializeField]
	private Transform _target;
	
	public void Highlight()
	{
		var target = _target != null ? _target : transform;
		target.localScale = Vector3.one * _factor;
	}

	public void CancelHighlight()
	{
		var target = _target != null ? _target : transform;
		target.localScale = Vector3.one;
	}
}