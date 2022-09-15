using UnityEngine;

public class SGun : Weapon, ISGun
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletStartPosition;

    private Transform _sgun;

    [Space]
    [SerializeField] private float _damageGun = 4;
    [SerializeField] private float _ammoGun = 30;
    [SerializeField] public float _allAmmoGun = 120; // total damage 600

    private const float ammo = 30;

    public float _damage => _damageGun;

    public new float _ammo => _ammoGun;

    public new float _allAmmo { get => _allAmmoGun; set => _allAmmoGun = value; }

    public float _timeToFite = 0.1f;

    public float _timer = 0;

    private void Start()
    {
        _sgun = GameObject.FindGameObjectWithTag("CreateWeaponController").transform;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timeToFite)
        {
            if (Input.GetMouseButtonDown(0) && _ammoGun > 0)
            {
                SGunFire();
                AmmunitionConsumption();
                _timer = 0;
            }
            else if (Input.GetMouseButton(0) && _ammoGun > 0)
            {
                SGunFire();
                AmmunitionConsumption();
                _timer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
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
