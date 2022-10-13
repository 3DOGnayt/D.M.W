using UnityEngine;

public class Bullet : MonoBehaviour/*, IBullet*/
{
    //public BulletType Type => _type;

    [SerializeField] private float _speed = 1;
    //[SerializeField] private BulletType _type; 
    private float _damage;

    public void InitDamage(float damage)
    {
        _damage = damage;       
        Destroy(gameObject, 3);
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