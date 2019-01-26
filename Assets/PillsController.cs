using UnityEngine;
using UnityEngine.UI;

public class PillsController : Singletone<PillsController>
{
	[SerializeField]
	private Button _useButton;

	private void Start()
	{
		_useButton.onClick.AddListener(() =>
		{
			ProgressController.Instance.PillsChanged(-1);
			ProgressController.Instance.ChangeInsanity(1);
		});
		_useButton.gameObject.SetActive(false);
	}

	public void PillsAmountChanged(int currentAmount)
	{
		_useButton.gameObject.SetActive(currentAmount > 0);
	}
}