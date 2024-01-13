using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _timeToDestroy = 2;
    private float _damage;

    public void InitDamage(float damage)
    {
        _damage = damage;
        //gameObject.SetActive(false);
        //Destroy(gameObject, _timeToDestroy);
    }

    private void Update()
    {
        _timeToDestroy -= Time.deltaTime;
        if (_timeToDestroy <= 0)
        {
            gameObject.SetActive(false);
            _timeToDestroy = 2;
        }
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out _))
        {
            other.GetComponent<ITakeDamage>().TakeDamage(_damage);
        }
        gameObject.SetActive(false);
    }
}