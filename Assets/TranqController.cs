using UnityEngine;
using UnityEngine.UI;

public class TranqController : Singletone<TranqController>
{
	[SerializeField]
	private Button _useButton;

	private void Start()
	{
		_useButton.onClick.AddListener(() =>
		{
			ProgressController.Instance.TranqChanged(-1);
			ProgressController.Instance.ChangeInsanity(1);
		});
		_useButton.gameObject.SetActive(false);
	}

	public void TranqAmountChanged(int currentAmount)
	{
		_useButton.gameObject.SetActive(currentAmount > 0);
	}
}