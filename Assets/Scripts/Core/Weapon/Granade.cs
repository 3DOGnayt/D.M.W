using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _radiusExplosion = 20f;
    [SerializeField] private float _explosionForse = 40f;
    [SerializeField] private float _explosionForseRadius = 40f;
    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;        
        Destroy(gameObject, 4);
    }

    private void Boom()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, _radiusExplosion);
        foreach (var item in hit)
        {
            if (item.GetComponent<Enemy>() != null)
            {
                item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForse, transform.position, _explosionForseRadius);
                item.gameObject.GetComponent<Enemy>().TakeDamage(_damage);  // damage x2 fix
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out _))
        {
            Boom();
        }
        else if (other.gameObject.TryGetComponent<MeshCollider>(out _))
        {
            Boom();
        }
    }
}
