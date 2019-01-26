using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechController : Singletone<SpeechController>
{
	[SerializeField] 
	private Transform _speechWorldPosition;
	[SerializeField] 
	private string[] _passivePhrases;
	[SerializeField] 
	private string[] _positiveAction;
	[SerializeField] 
	private string[] _negativeAction;
	[SerializeField] 
	private GameObject _speechWidgetRoot;
	[SerializeField] 
	private TextMeshProUGUI _speechText;
	[SerializeField] 
	private int _passiveActivateTimeInSeconds;
	
	private Coroutine _phraseTimer;
	private Coroutine _passiveTimer;
	
	[SerializeField]
	private CanvasScaler _canvas;

	private void Start()
	{
		_speechWidgetRoot.SetActive(false);
		RestartPassiveTimer();
	}

	public void PositiveAction()
	{
		StartPhraseShow(_positiveAction);
	}

	public void NegativeAction()
	{
		StartPhraseShow(_negativeAction);
	}

	private void RestartPassiveTimer()
	{
		if (_passiveTimer != null)
			StopCoroutine(_passiveTimer);
		_passiveTimer = StartCoroutine(PassiveTimer());
	}

	private IEnumerator PassiveTimer()
	{
		yield return new WaitForSeconds(_passiveActivateTimeInSeconds);
		StartPhraseShow(_passivePhrases);
		_passiveTimer = null;
	}

	private void StartPhraseShow(string[] pool)
	{
		if (_phraseTimer != null)
			StopCoroutine(_phraseTimer);
		_phraseTimer = StartCoroutine(ShowPhraseTimed(GetRandomPhrase(pool)));
		RestartPassiveTimer();
	}
	
	private string GetRandomPhrase(string[] pool)
	{
		return pool[Random.Range(0, pool.Length)];
	}

	private IEnumerator ShowPhraseTimed(string phrase)
	{
		_speechText.text = phrase;
		_speechWidgetRoot.SetActive(true);
		yield return new WaitForSeconds(2f);
		_speechWidgetRoot.SetActive(false);
		_phraseTimer = null;
		//todo: restart passive timer
	}
	
	private void Update()
	{
		var screenPoint = Camera.main.WorldToScreenPoint(_speechWorldPosition.transform.position);
		var scaleReference = new Vector2(_canvas.referenceResolution.x / Screen.width, _canvas.referenceResolution.y / Screen.height);
		_speechWidgetRoot.GetComponent<RectTransform>().anchoredPosition = Vector2.Scale(screenPoint, scaleReference);;
	}
}
