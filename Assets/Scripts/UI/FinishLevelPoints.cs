using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishLevelPoints : MonoBehaviour
{
    [SerializeField] Text _numberLevelEnd;
    [SerializeField] Text _enemyKills;
    [SerializeField] Text _levelPoints;
    [SerializeField] Text _allLevelPoints;

    [SerializeField] private FinishLevel _finishLevelPoints;

    private Player _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start() //exactly, I can regroup this code on 3, but...
    {
        #region GameModeCheck
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1) && (_finishLevelPoints._mode == 0 || _finishLevelPoints._mode == 2))
        {
            _finishLevelPoints._nextLevel.interactable = false;
            Debug.Log("an interactable");
        }
        else
        {
            _finishLevelPoints._nextLevel.interactable = true;
            Debug.Log("an interactable");
        }        
        
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1) && _finishLevelPoints._mode == 1)
        {
            _finishLevelPoints._nextLevel.interactable = true;
            Debug.Log("interactable");
        }
        #endregion

        #region Points
        if (!PlayerPrefs.HasKey("Points"))
        {
            PlayerPrefs.SetFloat("Points", _player._points);
            PlayerPrefs.SetFloat("KillPoints", _player._killPoints);
            Debug.Log("Points save");
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetFloat("Points", _player._points);
            PlayerPrefs.SetFloat("KillPoints", _player._killPoints);
            Debug.Log("Points new seve 1");
        }
        else
        {
            PlayerPrefs.SetFloat("Points", _player._points + PlayerPrefs.GetFloat("Points"));
            PlayerPrefs.SetFloat("KillPoints", _player._killPoints + PlayerPrefs.GetFloat("KillPoints"));
            Debug.Log("Points new seve N");
        }
        #endregion

        #region LevelEnd
        if (SceneManager.GetActiveScene().buildIndex == (SceneManager.sceneCountInBuildSettings - 1))
        {
            _numberLevelEnd.text = $"Last level {SceneManager.GetActiveScene().buildIndex} complete";
            _enemyKills.text = $"Kills - {_player._killPoints}";
            _levelPoints.text = $"Points - {_player._points}";
            _allLevelPoints.text = $"All points - {PlayerPrefs.GetFloat("Points")}";
        }
        else
        {
            _numberLevelEnd.text = $"Level {SceneManager.GetActiveScene().buildIndex} complete";
            _enemyKills.text = $"Kills - {_player._killPoints}";
            _levelPoints.text = $"Points - {_player._points}";
            _allLevelPoints.text = $"All points - {PlayerPrefs.GetFloat("Points")}";
        }
        #endregion
    }
}
