using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private GameObject _settingsInGame;

    private void Awake()
    {
        Time.timeScale = 1f;

        _pause.onClick.AddListener(PauseInGame);
    }

    private void PauseInGame()
    {
        _settingsInGame.SetActive(true);
        _pause.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
}
