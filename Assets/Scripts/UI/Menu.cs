using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMemu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _changeLevelMenu;
    [SerializeField] private GameObject _points;

    [SerializeField] private Button _start;
    [SerializeField] private Button _continue;
    [SerializeField] private Button _settings;
    [SerializeField] private Button _changeLevel;
    [SerializeField] private Button _exit;

    private void Awake()
    {
        _start.onClick.AddListener(StartGame);
        _continue.onClick.AddListener(StartGame);
        _settings.onClick.AddListener(Settings);
        _changeLevel.onClick.AddListener(ChangeLevel);
        _exit.onClick.AddListener(ExitGame);
        _points.SetActive(false);
    }

    private void StartGame()
    {
        _mainMemu.SetActive(false);
        _points.SetActive(true);
        if (PlayerPrefs.GetInt("LevelSave") > 1)
        {
            SaveLevel s = new SaveLevel();
            s.Load();
        }
        else
        SceneManager.LoadScene(1);
    }

    private void Settings()
    {
        _mainMemu.SetActive(false);
        _settingsMenu.SetActive(true);
    }

    private void ChangeLevel()
    {
        _mainMemu.SetActive(false);
        _changeLevelMenu.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
