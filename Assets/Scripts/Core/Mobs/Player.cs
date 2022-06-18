using UnityEngine;

public class Player : MonoBehaviour, ITakeDamage, ITakeHp, ILookOnMouse
{
    [SerializeField] private int _hp = 100;
    [SerializeField] private int _speed = 2;

    public LayerMask LayerMask;
    public bool _haveWeapon = false;

    private Camera _cam;
    private Transform _transform;
    //private Rigidbody _rigidbody;

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _cam = Camera.main;
        //_rigidbody = GetComponent<Rigidbody>();
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
            //_rigidbody.AddForce(0, 0, _speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.S))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x,
                transform.position.y, transform.position.z - 1), _speed * Time.deltaTime);
        //_rigidbody.AddForce(0, 0, -_speed, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.A))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x - 1,
                transform.position.y, transform.position.z), _speed * Time.deltaTime);
        //_rigidbody.AddForce(-_speed, 0, 0, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.D))
            _transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + 1,
                transform.position.y, transform.position.z), _speed * Time.deltaTime);
        //_rigidbody.AddForce(_speed, 0, 0, ForceMode.Impulse);
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

    public void LookOnMouse()
    {
        Ray rayCAM = _cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(_cam.transform.position, rayCAM.direction * 20f, Color.green);

        Physics.Raycast(rayCAM, out RaycastHit hit, 50f, LayerMask);
        Vector3 groundHit = hit.point;
        transform.LookAt(new Vector3(groundHit.x, groundHit.y + 0.5f, groundHit.z));
    }
}
