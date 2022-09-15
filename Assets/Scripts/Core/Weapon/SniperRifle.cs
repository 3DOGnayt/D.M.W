using UnityEngine;

public class SniperRifle : Weapon, ISniperRifle
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _sniperRifle;

    [Space]
    [SerializeField] private float _damageGun = 40;
    [SerializeField] private float _ammoGun = 5;
    [SerializeField] public float _allAmmoGun = 20; // total damage 1000 

    private const float ammo = 5;

    public float _damage => _damageGun;

    public new float _ammo => _ammoGun;

    public new float _allAmmo { get => _allAmmoGun; set => _allAmmoGun = value; }

    private void Start()
    {
        _sniperRifle = GameObject.FindGameObjectWithTag("CreateWeaponController").transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _ammoGun > 0)
        {
            SniperRifleFire();
            AmmunitionConsumption();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
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
