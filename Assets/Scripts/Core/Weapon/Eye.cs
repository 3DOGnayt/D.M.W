using UnityEngine;

public class Eye : Weapon, ILaser
{
    public Camera _camera;
    public LineRenderer _lineRenderer;
    public Transform _laserStartPosition;
    public LayerMask _layerMask;

    private Transform _eye;
    private Ray _ray;
    private Ray _rayEye;
    private RaycastHit _hit;
    private Vector3 _mousePosition;
    //private Vector3 _rangeToMouse;
    //private float _rangePoint;

    [Space]
    [SerializeField] private float _damageGun = 1;
    [SerializeField] private float _ammoGun = 1000;
    [SerializeField] public float _allAmmoGun = 1000; // total damage 2000

    private const float ammo = 1000;
    public float _damage => _damageGun;
    public new float _ammo => _ammoGun;
    public new float _allAmmo { get => _allAmmoGun; set => _allAmmoGun = value; }

    [Space]     
    [SerializeField] private float _range;
    [Space]
    [SerializeField] private float _timer = 0;
    [SerializeField] private float _timeToFite = 0.1f;
    [Space]
    [SerializeField] private float _timerReload = 0;
    [SerializeField] private float _timeToReload = 2f;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _camera = Camera.main;
    }

    private void Start()
    {
        _eye = GameObject.FindGameObjectWithTag("CreateWeaponController").transform;
        _timerReload = _timeToReload;
    }

    private void Update()
    {
        _timerReload += Time.deltaTime;
        _timer += Time.deltaTime;

        if (_timer >= _timeToFite && _timerReload >= _timeToReload)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && _ammoGun > 0)
            {
                _lineRenderer.enabled = true;
                LaserFire();
                AmmunitionConsumption();
                _timer = 0;
            }
            else
            {
                _lineRenderer.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void FixedUpdate()
    {
        transform.position = _eye.position;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_camera.transform.position, _ray.direction * 20f, Color.blue);

        Physics.Raycast(_ray, out _hit, 50f, _layerMask);
        Vector3 groundHit = _hit.point;
        _mousePosition = new Vector3(groundHit.x, groundHit.y + 0.5f, groundHit.z);
        transform.LookAt(_mousePosition);

        _rayEye = new Ray(transform.position, _laserStartPosition.forward);
        Debug.DrawRay(_laserStartPosition.position, _rayEye.direction * _range, Color.white);

        _lineRenderer.SetPosition(0, _laserStartPosition.position);
        _lineRenderer.SetPosition(1, _mousePosition);
        #region try to cut over range
        //_rangeToMouse = _mousePosition - _laserStartPosition.position; // lenght (eye=>mouse) change 1-2 | 2-1
        //var overRange = new Vector3(_laserStartPosition.position.x + _range, _laserStartPosition.position.y, _laserStartPosition.position.z + _range);
        //_rangePoint = (_mousePosition - _laserStartPosition.position).magnitude - _range;


        //if (_range >= _rangeToMouse.sqrMagnitude)
        //{
        //    _lineRenderer.SetPosition(0, _laserStartPosition.position);
        //    _lineRenderer.SetPosition(1, _mousePosition);
        //}
        //else if (_range < _rangeToMouse.sqrMagnitude)
        //{
        //    _lineRenderer.SetPosition(0, _laserStartPosition.position);
        //    _lineRenderer.SetPosition(1, _mousePosition); // last point lenght _range
        //}
        #endregion
    }

    public void LaserFire()
    {
        #region try
        //if (_range >= _rangeToMouse.sqrMagnitude)
        //{
        //    RaycastHit[] hit = Physics.RaycastAll(transform.position, _laserStartPosition.forward, _rangeToMouse.magnitude);

        //    foreach (var item in hit)
        //    {
        //        Debug.Log(hit);
        //        if (/*Physics.Raycast(_rayEye, out _hit, _range) &&*/ item.collider.gameObject.GetComponent<Enemy>() != null)
        //        {
        //            item.collider.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
        //        }
        //        else return;
        //    }
        //}
        //else if (_range < _rangeToMouse.sqrMagnitude)
        //{
        //    RaycastHit[] hit = Physics.RaycastAll(transform.position, _laserStartPosition.forward, _range);

        //    foreach (var item in hit)
        //    {
        //        Debug.Log(hit);
        //        if (/*Physics.Raycast(_rayEye, out _hit, _range) &&*/ item.collider.gameObject.GetComponent<Enemy>() != null)
        //        {
        //            item.collider.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
        //        }
        //        else return;
        //    }
        //}
        #endregion
        RaycastHit[] hit = Physics.RaycastAll(transform.position, _laserStartPosition.forward, _range);

        foreach (var item in hit)
        {
            Debug.Log(hit);
            if (item.collider.gameObject.GetComponent<Enemy>() != null)
            {
                item.collider.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
            }
            else return;
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
        _timerReload = 0;

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
