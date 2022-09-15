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

    [Space]
    [SerializeField] private float _damageGun = 1;
    [SerializeField] private float _ammoGun = 1000;
    [SerializeField] public float _allAmmoGun = 1000; // total damage 2000

    private const float ammo = 1000;

    public float _damage => _damageGun;

    public new float _ammo => _ammoGun;

    public new float _allAmmo { get => _allAmmoGun; set => _allAmmoGun = value; }

    [Space]
    public float _range;

    [Space]
    public float _timer = 0;
    public float _startLaser = 0.1f;


    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _camera = Camera.main;
    }

    private void Start()
    {
        _eye = GameObject.FindGameObjectWithTag("CreateWeaponController").transform;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _startLaser)
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && _ammoGun > 0)
            {
                _lineRenderer.enabled = true;
                LaserFire();
                AmmunitionConsumption();
                _timer = 0;
            }
            else /*if (Input.GetMouseButtonUp(0))*/
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
        //transform.rotation = _eye.rotation;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_camera.transform.position, _ray.direction * 20f, Color.blue);

        Physics.Raycast(_ray, out _hit, 50f, _layerMask);
        Vector3 groundHit = _hit.point;
        Vector3 mousePosition = new Vector3(groundHit.x, groundHit.y + 0.5f, groundHit.z);
        transform.LookAt(mousePosition);

        _rayEye = new Ray(transform.position, _laserStartPosition.forward);
        Debug.DrawRay(_laserStartPosition.position, _rayEye.direction * 20f, Color.white);

        _lineRenderer.SetPosition(0, _laserStartPosition.position);
        _lineRenderer.SetPosition(1, mousePosition);
    }

    public void LaserFire()
    {
        RaycastHit[] hit = Physics.RaycastAll(transform.position, _laserStartPosition.forward, _range);

        foreach (var item in hit)
        {
            Debug.Log(hit);
            if (/*Physics.Raycast(_rayEye, out _hit, _range) &&*/ item.collider.gameObject.GetComponent<Enemy>() != null)
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
