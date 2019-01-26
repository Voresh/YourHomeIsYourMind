using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressController: Singletone<ProgressController>
{
    [SerializeField] 
    private TextMeshProUGUI _adCountVisual;
    private int _adCount;
    [SerializeField] 
    private TextMeshProUGUI _tranqCountVisual;
    private int _tranqCount;
    [SerializeField] 
    private int _insanityAmount = 1500;
    [SerializeField] 
    private Image _healthFill;

    private int _currentInsanity = 600;

    public void Start()
    {
        _tranqCountVisual.text = "x" + 0;
        _adCountVisual.text = "x" + 0;
        _healthFill.fillAmount = (float) _currentInsanity / _insanityAmount;
    }
    
    public void TranqChanged(int difference)
    {
        _tranqCount += difference;
        _tranqCountVisual.text = "x" + _tranqCount;
        SpeechController.Instance.PositiveAction();
        TranqController.Instance.TranqAmountChanged(_tranqCount);
    }
    
    public void ADChanged(int difference)
    {
        _adCount += difference;
        _adCountVisual.text = "x" + _adCount;
        SpeechController.Instance.PositiveAction();
    }

    public void ChangeInsanity(int difference)
    {
        SpeechController.Instance.NegativeAction();
        _currentInsanity += difference;
        StateObservable.Instance.ChangeState(_currentInsanity, _insanityAmount);
        _healthFill.fillAmount = (float) _currentInsanity / _insanityAmount;
        if (_currentInsanity >= _insanityAmount)
        {
            InteractionController.Instance.InteractionEnabled = false;
            GameOverController.Instance.gameObject.SetActive(true);
        }
        else if (_currentInsanity <= 0)
        {
            InteractionController.Instance.InteractionEnabled = false;
            WinController.Instance.gameObject.SetActive(true);
        }
    }
}