using UnityEngine;

public class Gun : Weapon, IGun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _gun;

    [Space]
    [SerializeField] private float _damageGun = 8;
    [SerializeField] private float _ammoGun = 7;
    [SerializeField] public float _allAmmoGun = 42; // total damage 392

    private const float ammo = 7; // for reload

    public float _damage => _damageGun;

    public new float _ammo => _ammoGun;

    public new float _allAmmo { get => _allAmmoGun; set => _allAmmoGun = value; }

    private void Start()
    {
        _gun = GameObject.FindGameObjectWithTag("CreateWeaponController").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ammoGun > 0)
        {
            GunFire();
            AmmunitionConsumption();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void FixedUpdate()
    {
        transform.position = _gun.position;
        transform.rotation = _gun.rotation;
    } 

    public void GunFire() // need turn on instantiation weapon
    {
        var bullet = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        bullet.InitDamage(_damage);
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
