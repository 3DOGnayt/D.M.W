using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] private GameObject _mainMemu;
    [SerializeField] private GameObject _settingsMenu;

    [SerializeField] private Dropdown _dropdown;

    [SerializeField] private Button _close;
    [SerializeField] private Button _load;

    private int level;

    private void Awake()
    {
        _load.onClick.AddListener(LoadScene);
        _close.onClick.AddListener(CloseSettings);
    }

    private void Start()
    {
        _dropdown.options = new List<Dropdown.OptionData>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            _dropdown.options.Add(new Dropdown.OptionData($"Level {i}"));
        }
        level = SceneManager.GetActiveScene().buildIndex;
    }

    private void CloseSettings()
    {
        _settingsMenu.SetActive(false);
        _mainMemu.SetActive(true);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_dropdown.value + 1);
    }
}
