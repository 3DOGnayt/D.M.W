using UnityEngine;

public class Gun : MonoBehaviour
{
    public void Fire(GameObject bullet)
    {
        bullet = Instantiate(gameObject, transform.forward, Quaternion.identity);
        Destroy(gameObject, 2f);
    }
}
