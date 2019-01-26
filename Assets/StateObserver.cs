using System;
using UnityEngine;

public class StateObserver : MonoBehaviour
{
	[SerializeField] 
	private Animator _animator;
	[SerializeField] 
	private string[] _statesNames;
	[SerializeField] 
	private Transform[] _positions;
	
	public void ChangeState(int state)
	{
		if (_statesNames.Length != 0)
			_animator.Play(_statesNames[Mathf.Clamp(state, 0, _statesNames.Length)]);
		if (_positions.Length != 0)
		transform.position = _positions[Mathf.Clamp(state, 0, _positions.Length)].position;
	}
}