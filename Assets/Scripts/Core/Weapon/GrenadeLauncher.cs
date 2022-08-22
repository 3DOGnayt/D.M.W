using UnityEngine;

public class GrenadeLauncher : Bullet, IGrenadeLauncher
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _grenadeLauncher;

    [Space]
    [SerializeField] private float _damageGun = 10;
    [SerializeField] private float _ammoGun = 3;
    [SerializeField] private float _allAmmoGun = 33; // total damage 720

    private const float ammo = 3;

    public float _damage  => _damageGun;

    public float _ammo => _ammoGun;

    private void Start()
    {
        _grenadeLauncher = GameObject.FindGameObjectWithTag("CreateWeaponController").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ammoGun > 0)
        {
            GranadeLauncherFire();
            AmmunitionConsumption();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
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
