using System.Collections.Generic;
using UnityEngine;

public class DropAmmo : MonoBehaviour
{
    [SerializeField] private List<GameObject> _ammo = new List<GameObject>();

    public void Drop()
    {
        int ranom = Random.Range(0, _ammo.Count);
        Instantiate(_ammo[ranom], transform.position, transform.rotation);
    }
}
