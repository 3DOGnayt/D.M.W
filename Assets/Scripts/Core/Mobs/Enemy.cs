using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage, ITakePoints, IPoints
{
    [SerializeField] public float _maxHp = 20;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _damage = 2;
    [SerializeField] private float _enemyPoints;
    [SerializeField] private DropAmmo _dropAmmo;

    private Transform _target;

    public float _CurrentHp { get; private set; }

    public float _points => _enemyPoints;

    private void Awake()
    {
        _CurrentHp = _maxHp;

        if (GameObject.FindGameObjectWithTag("Player").transform)
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else return;
        //_target = GameObject.FindGameObjectWithTag("Player").transform;
        _dropAmmo = GetComponent<DropAmmo>();
    }

    private void Update()
    {
        if (_target)
        {
            transform.LookAt(_target.transform);
            transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        }
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);

            // Ќужно сделать так, чтобы врага отталкивало от игрока после удара в противопроложную сторону (-LookAt)
            //transform.Translate(new Vector3(_target.position.x - (transform.position.x),
            //    0, _target.position.z - (transform.position.z)));
            Vector3 pos = Vector3.Lerp(transform.position, new Vector3(transform.position.x,
                transform.position.y, transform.position.z - 2f) , 2 * Time.deltaTime);
            transform.Translate(pos);
        }
    }

    public void TakeDamage(float damage)
    {
        if (_maxHp > 0)
            _maxHp -= damage;
        else
        {
            _dropAmmo.Drop();
            TakePoints();
            Destroy(gameObject);
        } 
    }

    public void TakePoints()
    {
        _target.GetComponent<Player>()._points += _points;
        Debug.Log($"take ({_points}) points from - {name}");
    }
}
