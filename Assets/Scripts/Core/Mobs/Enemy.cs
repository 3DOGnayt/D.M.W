using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage, ITakePoints, IPoints, IKillCounts, IKillPoints
{
    [SerializeField] public float _maxHp = 20;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _moveDistance = 16;
    [SerializeField] private float _damage = 2;
    [SerializeField] private float _enemyPoints;
    [SerializeField] private float _enemyKillPoints;
    [SerializeField] private DropAmmo _dropAmmo;
    [SerializeField] private Player _player;

    private bool _isDestroed;
    public bool _boom;

    public float _CurrentHp { get; private set; }

    public float _points => _enemyPoints;

    public float _killPoints => _enemyKillPoints;

    private void Awake()
    {
        _CurrentHp = _maxHp;
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        _dropAmmo = GetComponent<DropAmmo>();
    }

    private void Update()
    {
        if (_boom == true)
        {
            StartCoroutine(BoomReturn());
        }

        if (_player.transform)
        {
            transform.LookAt(_player.transform);
            transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        }
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
            transform.Translate(new Vector3(0, 0, -(_speed * _moveDistance) * Time.fixedDeltaTime));            
        }
    }

    public void TakeDamage(float damage)
    {
        if(_maxHp > 0)
        {
            if (_maxHp > damage)
                _maxHp -= damage;
            else if(_maxHp <= damage && _isDestroed == false)
            {
                _isDestroed = true;
                _dropAmmo.Drop();
                TakePoints();
                KillCounts();
                Destroy(gameObject);
            }
        }
    }

    public void TakePoints()
    {
        _player.GetComponent<Player>()._points += _points;
        Debug.Log($"take ({_points}) points from - {name}");
    }

    public void KillCounts()
    {
        _player.GetComponent<Player>()._killPoints += _killPoints;
        Debug.Log($"take ({_killPoints}) killpoint from - {name}");
    }

    IEnumerator BoomReturn()
    {
        yield return new WaitForSeconds(0.2f);
        _boom = false;
    }
}
