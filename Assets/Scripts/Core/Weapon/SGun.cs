using UnityEngine;

public class SGun : Bullet, ISGun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _sgun;

    public float _damage => 2;

    public float _ammo => 30;

    public float _timeToFite = 0.1f;

    public float _timer = 0;

    private void Start()
    {
        _sgun = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToFite)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SGunFire();
                _timer = 0;
            }
            else if (Input.GetMouseButton(0))
            {
                SGunFire();
                _timer = 0;
            }
        }        
    }

    private void FixedUpdate()
    {
        transform.position = _sgun.position;
        transform.rotation = _sgun.rotation;        
    }

    public void SGunFire()
    {
        var bullet = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bullet.Init(_damage);
    }

    public void Reload()
    {
        
    }
}
