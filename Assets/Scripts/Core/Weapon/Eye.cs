using UnityEngine;

public class Eye : MonoBehaviour, ILaser
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
    public float _range;
    public float _damage => 2;

    public float _ammo => 2000;

    [Space]
    public float _timer = 0;
    public float _startLaser = 0.5f;


    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.enabled = false;
        _camera = Camera.main;
    }

    private void Start()
    {
        _eye = GameObject.FindGameObjectWithTag("Weapon").transform;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _startLaser)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                _lineRenderer.enabled = true;
                LaserFire();
                _timer = 0;
            }
            else /*if (Input.GetMouseButtonUp(0))*/
            {
                _lineRenderer.enabled = false;
            }
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

    public void Reload()
    {
        
    }
}
