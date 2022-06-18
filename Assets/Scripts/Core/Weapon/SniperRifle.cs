using UnityEngine;

public class SniperRifle : Bullet, IWeapon, IDamage
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _sniperRifle;

    public int _damage => 10;

    private void Start()
    {
        _sniperRifle = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SniperRifleFire();
        }
    }

    private void FixedUpdate()
    {
        transform.position = _sniperRifle.position;
        transform.rotation = _sniperRifle.rotation;
    }

    public void SniperRifleFire()
    {
        var bullet = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bullet.Init(_damage);
    }
}
