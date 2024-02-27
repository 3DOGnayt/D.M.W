using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField] private Text _pointsText;

    private Player _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();  // this method faster than instantiating player        
    }

    private void FindPlayer()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {        
        if (_player._points <= 1)
             _pointsText.text = _player._points + " " + "point";
        else _pointsText.text = _player._points + " " + "points";
        if (_player) return;
        FindPlayer();
    }
}
