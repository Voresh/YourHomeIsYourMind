public class StateObservable : Singletone<StateObservable>
{
	private StateObserver[] _stateObservers;

	private void Start()
	{
		_stateObservers = FindObjectsOfType<StateObserver>();
	}

	public void ChangeState(int current, int max)
	{
		int state;
		if (current < max / 3f)
			state = 0;
		else if (current < max * 2 / 3f)
			state = 1;
		else
			state = 2;
		foreach (var observer in _stateObservers)
		{
			observer.ChangeState(state);
		}
	}
}