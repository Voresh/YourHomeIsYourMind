using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController: Singletone<GameOverController>
{
    [SerializeField] 
    private Button _restartButton;

    private void Start()
    {
        gameObject.SetActive(false);
        _restartButton.onClick.AddListener(() => { SceneManager.LoadScene(0); });
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveAllListeners();
    }
}