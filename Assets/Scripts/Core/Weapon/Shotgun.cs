using UnityEngine;

public class Shotgun : Bullet, IShotgun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _bulletStartPosition;

    private Transform _shotgun;

    [Space]
    [SerializeField] private float _damageGun = 3;
    [SerializeField] private float _ammoGun = 6;
    [SerializeField] private float _allAmmoGun = 42; // total damage 864

    private const float ammo = 6;

    public float _damage => _damageGun;

    public float _ammo => _ammoGun;

    private void Start()
    {
        _shotgun = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ammoGun > 0)
        {
            ShotgunFire();
            AmmunitionConsumption();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
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

    public void AmmunitionConsumption()
    {
        _ammoGun--;
        if (_ammoGun <= 0)
        {
            Reload();
        }
    }

    public void Reload()
    {
        if (_allAmmoGun > 0)
        {
            if (_allAmmoGun >= ammo)
            {
                if (_ammoGun <= 0)
                {
                    _allAmmoGun = _allAmmoGun - ammo;
                    _ammoGun = _ammoGun + ammo;
                }
                else if (_ammoGun < ammo)
                {
                    _allAmmoGun = (_allAmmoGun + _ammoGun) - ammo;
                    _ammoGun = ammo;
                }
            }
            else if (_allAmmoGun < ammo)
            {
                if (_ammoGun <= 0)
                {
                    _ammoGun = _ammoGun + _allAmmoGun;
                    _allAmmoGun = 0;
                }
                else if (_ammoGun < ammo)
                {
                    _allAmmoGun = _allAmmoGun + _ammoGun;
                    _ammoGun = 0;
                    if (_allAmmoGun >= ammo)
                    {
                        _allAmmoGun = _allAmmoGun - ammo;
                        _ammoGun = _ammoGun + ammo;
                    }
                    else if (_allAmmoGun < ammo)
                    {
                        _ammoGun = _ammoGun + _allAmmoGun;
                        _allAmmoGun = 0;
                    }
                }
            }
        }
        else if (_allAmmoGun <= 0) return;
    }
}
