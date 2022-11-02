using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu;
    [Space]
    [SerializeField] private Button _restart;
    [SerializeField] public Button _nextLevel;
    [SerializeField] private Button _reternInMenu;

    public int _mode = 0;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
        _nextLevel.onClick.AddListener(NextLevel);
        _reternInMenu.onClick.AddListener(RetertInMenu);
        _finishMenu.SetActive(false);
    }

    private void Restart()
    {
        _finishMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextLevel()
    {
        _finishMenu.SetActive(false);
        
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1) && _mode == 1)
        {
            SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings - 1));
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // if _mode = 0/2 - button nextlevel off
    }

    private void RetertInMenu()
    {
        _finishMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }   
}
