using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _radiusExplosion = 20f;
    [SerializeField] private float _explosionForse = 40f;
    [SerializeField] private float _explosionForseRadius = 40f;
    private int _damage;

    public void Init(int damage)
    {
        _damage = damage;        
        Destroy(gameObject, 4);
    }

    private void Boom()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, _radiusExplosion);
        foreach (var item in hit)
        {
            //var rigitbody = item.GetComponent<Rigidbody>();

            if (/*rigitbody != null*/ item.GetComponent<Enemy>() != null)
            {
                //rigitbody.AddExplosionForce(_explosionForse, transform.position, _explosionForseRadius);
                //rigitbody.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
                item.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForse, transform.position, _explosionForseRadius);
                item.gameObject.GetComponent<Enemy>().TakeDamage(_damage);  // damage x2 fix
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        //gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out _))
        {
            Boom();
            //other.gameObject.GetComponent<ITakeDamage>().TakeDamage(0);
            //Destroy(gameObject);
        }
        else if (other.gameObject.TryGetComponent<MeshCollider>(out _))
        {
            Boom();
            //Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.TryGetComponent<Enemy>(out _))
    //    {
    //        Boom();
    //        other.GetComponent<ITakeDamage>().TakeDamage(_damage);
    //        Destroy(gameObject);
    //    }
    //    else if (other.gameObject.TryGetComponent<MeshCollider>(out _))
    //    {
    //        Boom();
    //        other.GetComponent<ITakeDamage>().TakeDamage(_damage);
    //        Destroy(gameObject);
    //    }        
    //}
}
