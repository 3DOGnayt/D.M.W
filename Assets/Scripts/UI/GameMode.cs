using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMode : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameMode;
    [SerializeField] private GameObject _chelenges;

    [SerializeField] private Dropdown _dropdown;

    [SerializeField] private Button _change;
    [SerializeField] private Button _close;

    [SerializeField] private FinishLevel _finishLevel;

    [SerializeField] private List<string> _gameModeList = new List<string>();

    private void Awake()
    {
        _close.onClick.AddListener(CloseGameMode);
        _change.onClick.AddListener(ChangeGameMode);
    }

    private void Start()
    {
        _gameModeList.Add("Company");
        _gameModeList.Add("Endless Mode");
        _gameModeList.Add("Challenge Mode");

        _dropdown.options = new List<Dropdown.OptionData>();

        for (int i = 0; i < _gameModeList.Count; i++)
        {
            _dropdown.options.Add(new Dropdown.OptionData($"{_gameModeList[i]}"));
        }

        if (!PlayerPrefs.HasKey("GameMode")) // Company
        {
            PlayerPrefs.SetInt("GameMode", 0);
            _finishLevel._mode = 0;
        }

        if (PlayerPrefs.GetInt("GameMode") == 0) // Company
        {
            _finishLevel._mode = 0;
            _chelenges.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameMode") == 1) // Endless mode
        {
            _finishLevel._mode = 1;
            _chelenges.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("GameMode") == 2 && SceneManager.GetActiveScene().buildIndex >= 1) // Chalenge mode
        {
            _chelenges.SetActive(true);
            _finishLevel._mode = 2;
        }

        Debug.Log($"GameMode {PlayerPrefs.GetInt("GameMode", _dropdown.value)}");
    }

    private void ChangeGameMode()
    {
        PlayerPrefs.SetInt("GameMode", _dropdown.value);
        Debug.Log($"{PlayerPrefs.GetInt("GameMode", _dropdown.value)}");
        CloseGameMode();
    }

    private void CloseGameMode()
    {
        _gameMode.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
