using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{
    [SerializeField] private GameObject _settingsInGameMenu;
    [SerializeField] private Button _pause;

    [SerializeField] private Slider _volume;
    [SerializeField] private Toggle _mute;

    [SerializeField] private Button _menu;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _close;

    private Player _player;

    private void Awake()
    {
        _volume.onValueChanged.AddListener(SetVolume);
        _mute.onValueChanged.AddListener(MuteGame);

        _menu.onClick.AddListener(ReturnToMenu);
        _restart.onClick.AddListener(RestartGame);
        _close.onClick.AddListener(CloseSettings);

        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void SetVolume(float value)
    {

    }

    private void MuteGame(bool value)
    {

    }

    private void ReturnToMenu()
    {
        _settingsInGameMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    private void CloseSettings()
    {
        Time.timeScale = 1f;
        _settingsInGameMenu.SetActive(false);
        _pause.gameObject.SetActive(true);
        _player.GetComponent<Player>().enabled = true;
    }

    private void RestartGame()
    {
        CloseSettings();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
