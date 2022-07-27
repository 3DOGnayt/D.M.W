using UnityEngine;

public class Shotgun : Bullet, IShotgun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _bulletStartPosition;

    private Transform _shotgun;

    public float _damage => 2;

    public float _ammo => 6;

    private void Start()
    {
        _shotgun = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShotgunFire();
        }
    }

    private void FixedUpdate()
    {
        transform.position = _shotgun.position;
        transform.rotation = _shotgun.rotation;
    }

    public void ShotgunFire()
    {
        for (int i = 0; i < _bulletStartPosition.Length; i++)
        {
            var bullet = Instantiate(_bullet, _bulletStartPosition[i].position, transform.rotation).GetComponent<Bullet>();
            bullet.Init(_damage);
        }        
    }

    public void Reload()
    {
       
    }
}
