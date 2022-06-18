using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    private int _damage;

    public void Init(int damage)
    {
        _damage = damage;       
        Destroy(gameObject, 4);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out _))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}