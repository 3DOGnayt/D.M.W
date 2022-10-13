using UnityEngine;
using UnityEngine.UI;

public class Chelenges : MonoBehaviour
{
    [SerializeField] private GameObject _finish;
    [Space]
    [SerializeField] private Text _killCount;
    [SerializeField] private float _countKillsToAnlockFinish;

    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        _killCount.text = $"Kill - {_player._killPoints}";
        
        if (_player._killPoints < _countKillsToAnlockFinish)
        {
            _finish.SetActive(false);
        }
        else if (_player._killPoints >= _countKillsToAnlockFinish)
        {
            _finish.SetActive(true);
        }
    }
}
