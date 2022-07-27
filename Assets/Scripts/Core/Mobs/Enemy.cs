using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float _hp = 20;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _damage = 2;

    private Transform _target;

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (_target)
        {
            transform.LookAt(_target.transform);
            transform.Translate(new Vector3(0, 0, _speed * Time.deltaTime));
        }
        return;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);

            // Нужно сделать так, чтобы врага отталкивало от игрока после удара в противопроложную сторону
            transform.Translate(new Vector3(_target.position.x - (transform.position.x),
                0, _target.position.z - (transform.position.z)));
            //^это не робит

        }
    }

    public void TakeDamage(float damage)
    {
        if (_hp > 0)
            _hp -= damage;
        else Destroy(gameObject);
    }
}
