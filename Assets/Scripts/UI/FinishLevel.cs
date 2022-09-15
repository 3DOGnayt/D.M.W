using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private GameObject _finishMenu;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _reternInMenu;

    private void Awake()
    {
        _restart.onClick.AddListener(Restart);
        _nextLevel.onClick.AddListener(NextLevel);
        _reternInMenu.onClick.AddListener(RetertInMenu);
    }

    private void Restart()
    {
        _finishMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void NextLevel()
    {
        _finishMenu.SetActive(false);
        
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
        {
            SceneManager.LoadScene(Random.Range(1, SceneManager.sceneCountInBuildSettings - 1));
        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void RetertInMenu()
    {
        _finishMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }   
}
