using TMPro;
using UnityEngine;

public class ProgressController: Singletone<ProgressController>
{
    [SerializeField] 
    private TextMeshProUGUI _pillsCountVisual;
    private int _pillsCount;
    [SerializeField] 
    private int _healthAmount;

    public void Start()
    {
        _pillsCountVisual.text = "x" + 0;
    }
    
    public void ChangeProgress(int difference)
    {
        _pillsCount += difference;
        _pillsCountVisual.text = "x" + _pillsCount;
    }

    public void ChangeHealth(int difference)
    {
        _healthAmount += difference;
        if (_healthAmount < 0)
        {
            InteractionController.Instance.InteractionEnabled = false;
            GameOverController.Instance.gameObject.SetActive(true);
        }
    }
}