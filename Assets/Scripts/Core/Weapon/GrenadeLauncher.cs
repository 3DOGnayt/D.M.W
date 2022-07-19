using UnityEngine;

public class GrenadeLauncher : Bullet, IWeapon, IDamage
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _grenadeLauncher;

    public int _damage => 5;

    private void Start()
    {
        _grenadeLauncher = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GranadeLauncherFire();
        }
    }

    private void FixedUpdate()
    {
        transform.position = _grenadeLauncher.position;
        transform.rotation = _grenadeLauncher.rotation;
    }

    public void GranadeLauncherFire()
    {
        var bullet = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Granade>();
        bullet.Init(_damage);
    }
}