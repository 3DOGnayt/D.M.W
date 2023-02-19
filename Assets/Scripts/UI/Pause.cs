using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _pause;
    [SerializeField] private GameObject _settingsInGame;
    [SerializeField] private GameObject _chalenges;
    [SerializeField] private GameObject _points;

    private Player _player;

    private void Awake()
    {
        Time.timeScale = 1f;
        _pause.onClick.AddListener(PauseInGame);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void PauseInGame()
    {
        _chalenges.SetActive(false);
        _points.SetActive(false);
        _settingsInGame.SetActive(true);
        _pause.gameObject.SetActive(false);
        _player.GetComponent<Player>().enabled = false;
        Time.timeScale = 0f;
    }
}
