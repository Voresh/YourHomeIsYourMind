using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController: Singletone<ProgressController>
{
    [SerializeField] 
    private TextMeshProUGUI _pillsCountVisual;
    private int _pillsCount;
    [SerializeField] 
    private int _insanityAmount = 1500;
    [SerializeField] 
    private Image _healthFill;

    private int _currentInsanity = 600;

    public void Start()
    {
        _pillsCountVisual.text = "x" + 0;
        _healthFill.fillAmount = (float) _currentInsanity / _insanityAmount;
    }
    
    public void PillsChanged(int difference)
    {
        _pillsCount += difference;
        _pillsCountVisual.text = "x" + _pillsCount;
        SpeechController.Instance.PositiveAction();
        PillsController.Instance.PillsAmountChanged(_pillsCount);
    }

    public void ChangeInsanity(int difference)
    {
        SpeechController.Instance.NegativeAction();
        _currentInsanity += difference;
        StateObservable.Instance.ChangeState(_currentInsanity, _insanityAmount);
        _healthFill.fillAmount = (float) _currentInsanity / _insanityAmount;
        if (_currentInsanity <= 0)
        {
            InteractionController.Instance.InteractionEnabled = false;
            GameOverController.Instance.gameObject.SetActive(true);
        }
    }
}