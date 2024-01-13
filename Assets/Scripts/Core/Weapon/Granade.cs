using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _radiusExplosion = 20f;
    [SerializeField] private float _explosionForse = 40f;
    [SerializeField] private float _explosionRadius = 40f;
    [SerializeField] private float _timeToDestroy = 2;

    private float _damage;

    public void Init(float damage)
    {
        _damage = damage;        
        Destroy(gameObject, _timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {  
            Boom();
        }
        else if (other.gameObject.TryGetComponent<MeshCollider>(out _))
        {
            Boom();
        }
    }

    private void Boom()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, _radiusExplosion);

        foreach (var item in hit)
        {
            item.TryGetComponent(out Enemy enemy);

            if (item.GetComponent<Enemy>() != null && enemy._boom == false)
            {
                enemy._boom = true;
                item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForse, transform.position, _explosionRadius);
                item.gameObject.GetComponent<ITakeDamage>().TakeDamage(_damage);  // damage x2 fix 
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
    }
}
