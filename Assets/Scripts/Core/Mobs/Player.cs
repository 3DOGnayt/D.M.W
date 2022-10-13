using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, ITakeHp, IPoints, ILookOnMouse, IKillPoints
{
    [SerializeField] private float _hp = 100;
    [SerializeField] private float _speed = 2;
    [SerializeField] private float _playerPoints;
    [SerializeField] private float _playerKillPoints;
    [Space]
    [SerializeField] private LayerMask LayerMask;
    [Space]
    public bool _haveWeapon = false;
    public bool _haveAmmo = false;

    private Camera _cam;
    private Transform _transform;

    public float _points { get => _playerPoints; set => _playerPoints = value; }

    public float _killPoints { get => _playerKillPoints; set => _playerKillPoints = value; }

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, ray.direction * 20f, Color.red);

        LookOnMouse();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, 
                transform.position.y, transform.position.z + 1), _speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,
                transform.position.y, transform.position.z - 1), _speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 1,
                transform.position.y, transform.position.z), _speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1,
                transform.position.y, transform.position.z), _speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (_hp > 0)
            _hp -= damage;
        else Destroy(gameObject);
    }

    public void TakeHp(float hp)
    {
        if (_hp < 100)
            _hp += hp;
        else return;
    }

    public void LookOnMouse()
    {
        Ray rayCAM = _cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_cam.transform.position, rayCAM.direction * 20f, Color.green);

        Physics.Raycast(rayCAM, out RaycastHit hit, 50f, LayerMask);
        Vector3 groundHit = hit.point;
        transform.LookAt(new Vector3(groundHit.x, groundHit.y + 0.5f, groundHit.z));
    }
}
