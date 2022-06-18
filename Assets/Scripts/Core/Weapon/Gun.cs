using UnityEngine;

public class Gun : Bullet, IWeapon, IGun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _gun;

    public int _damage => 5;

    private void Start()
    {
        _gun = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {       
        if (Input.GetMouseButtonDown(0))
        {
            GunFire();
        }
    }

    private void FixedUpdate()
    {
        transform.position = _gun.position;
        transform.rotation = _gun.rotation;
    } 

    public void GunFire()
    {
        var bullet = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bullet.Init(_damage);
    }
}
