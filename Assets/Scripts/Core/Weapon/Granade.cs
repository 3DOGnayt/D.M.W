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

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out _))
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy) && enemy._boom == true)
                enemy._boom = false;
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
                item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForse, transform.position, _explosionForseRadius);
                item.gameObject.GetComponent<ITakeDamage>().TakeDamage(_damage);  // damage x2 fix                
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
    }

}
