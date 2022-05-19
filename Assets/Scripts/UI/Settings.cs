using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject _mainMemu;
    [SerializeField] private GameObject _settingsMenu;

    [SerializeField] private Slider _volume;
    [SerializeField] private Toggle _mute;

    [SerializeField] private Button _close;

    private void Awake()
    {
        _volume.onValueChanged.AddListener(SetVolume);
        _mute.onValueChanged.AddListener(MuteGame);

        _close.onClick.AddListener(CloseSettings);
    }

    private void SetVolume(float value)
    {
        
    }

    private void MuteGame(bool value)
    {
        
    }

    
    private void CloseSettings()
    {
        _settingsMenu.SetActive(false);
        _mainMemu.SetActive(true);
    }
}
