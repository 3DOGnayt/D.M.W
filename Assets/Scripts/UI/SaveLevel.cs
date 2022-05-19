using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLevel : MonoBehaviour
{
    [SerializeField] private Button _startGame;
    [SerializeField] private Button _continue;

    [SerializeField] private Button _reset;
    [SerializeField] private Button _load;

    private int levelSave;

    private void Awake()
    {
        _reset.onClick.AddListener(Reset);
        _load.onClick.AddListener(Load);

        if (PlayerPrefs.GetInt("LevelSave") < 1)
        {
            _startGame.gameObject.SetActive(true);
            _continue.gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("LevelSave") >= 1)
        {
            _startGame.gameObject.SetActive(false);
            _continue.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        levelSave = SceneManager.GetActiveScene().buildIndex;

        if (!PlayerPrefs.HasKey("LevelSave"))
        {
            PlayerPrefs.SetInt("LevelSave", levelSave);
            Debug.Log("save");
        }

        if (PlayerPrefs.GetInt("LevelSave") < levelSave)
        {
            PlayerPrefs.SetInt("LevelSave", levelSave);
            Debug.Log("new_save");
        }
    }

    public void Load()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LevelSave"));
    }

    private void Reset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }
}
