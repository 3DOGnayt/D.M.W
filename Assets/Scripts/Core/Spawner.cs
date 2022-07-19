using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemy;

    [SerializeField] private float _positionX;
    [SerializeField] private float _positionY;
    [SerializeField] private float _positionZ;
    [Space]
    [SerializeField] private bool _dontSpawn = false;
    [Space]
    [SerializeField] private bool _everywhere = false;
    [SerializeField] private bool _xPosition = false;
    [SerializeField] private bool _zPosition = false;

    [SerializeField]private float _startSpawn;
    [SerializeField]private float _repeatSpawn;

    private void Start()
    {
        if (_dontSpawn == true)
        {
            _repeatSpawn = _startSpawn;
        }
        else return;
    }

    private void Update()
    {  
        if (_repeatSpawn <= 0)
        {
            switch (_everywhere, _xPosition, _zPosition)
            {
                case (true, false, false):
                    Vector3 positionAll = new Vector3(Random.Range(-_positionX, _positionX), _positionY, Random.Range(-_positionZ, _positionZ));
                    Instantiate(_enemy[Random.Range(0, _enemy.Length)], positionAll, Quaternion.identity);
                    _repeatSpawn = 2;
                    break;
                case (false, true, false):
                    Vector3 positionX = new Vector3(_positionX, _positionY, Random.Range(-_positionZ, _positionZ));
                    Instantiate(_enemy[Random.Range(0, _enemy.Length)], positionX, Quaternion.identity);
                    _repeatSpawn = 2;
                    break;
                case (false, false, true):
                    Vector3 positionZ = new Vector3(Random.Range(-_positionX, _positionX), _positionY, _positionZ);
                    Instantiate(_enemy[Random.Range(0, _enemy.Length)], positionZ, Quaternion.identity);
                    _repeatSpawn = 2;
                    break;
            }
        }
        else _repeatSpawn -= Time.deltaTime;
    }
}
