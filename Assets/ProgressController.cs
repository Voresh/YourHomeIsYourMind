using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController: Singletone<ProgressController>
{
    [SerializeField] 
    private TextMeshProUGUI _pillsCountVisual;
    private int _pillsCount;
    [SerializeField] 
    private int _healthAmount;
    [SerializeField] 
    private Image _healthFill;

    private int _currentHealth;

    public void Start()
    {
        _pillsCountVisual.text = "x" + 0;
        _healthFill.fillAmount = 1;
        _currentHealth = _healthAmount;
    }
    
    public void PillCollected()
    {
        SpeechController.Instance.PositiveAction();
        _pillsCount += 1;
        _pillsCountVisual.text = "x" + _pillsCount;
    }

    public void DamageReceived(int difference)
    {
        SpeechController.Instance.NegativeAction();
        _currentHealth += difference;
        _healthFill.fillAmount = (float) _currentHealth / _healthAmount;
        if (_currentHealth <= 0)
        {
            InteractionController.Instance.InteractionEnabled = false;
            GameOverController.Instance.gameObject.SetActive(true);
        }
    }
}