using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 50;
    private int _damage = 0;

    public void Init(int damage)
    {
        _damage = damage;
        Destroy(gameObject, 1);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}