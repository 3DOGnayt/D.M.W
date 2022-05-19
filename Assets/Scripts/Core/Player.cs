using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, ITakeHp
{
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _speed = 2;

    public LayerMask LayerMask;
    public GameObject _bullet;
    public Transform _bulletStartPosition;
    public int _damage = 6;

    private Camera _cam;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _cam = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Ray rayCAM = _cam.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(_cam.transform.position, rayCAM.direction * 20f, Color.green);
        Debug.DrawRay(transform.position, ray.direction * 20f, Color.red);

        Physics.Raycast(rayCAM, out RaycastHit hit, 50f, LayerMask);
        Vector3 h = hit.point;
        transform.LookAt(new Vector3(h.x, h.y + 0.5f, h.z));

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            _rigidbody.AddForce(0, 0, _speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            _rigidbody.AddForce(0, 0, -_speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.A))
            _rigidbody.AddForce(-_speed, 0, 0, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            _rigidbody.AddForce(_speed, 0, 0, ForceMode.Impulse);
    }

    public void Fire()
    {
        var b = Instantiate(_bullet, _bulletStartPosition.position, transform.rotation).GetComponent<Bullet>();
        b.Init(_damage);
    }

    public void TakeDamage(int damage)
    {
        if (_hp > 0)
            _hp -= damage;
        else Destroy(gameObject);
    }

    public void TakeHp(int hp)
    {
        if (_hp < 100)
            _hp += hp;
        else return;
    }
}
