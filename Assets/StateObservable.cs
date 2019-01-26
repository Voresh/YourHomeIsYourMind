public class StateObservable : Singletone<StateObservable>
{
	private int _currentState;
	private StateObserver[] _stateObservers;

	private void Start()
	{
		_stateObservers = FindObjectsOfType<StateObserver>();
	}

	public void ChangeState(int difference)
	{
		_currentState += difference;
		foreach (var observer in _stateObservers)
		{
			observer.ChangeState(_currentState);
		}
	}
}