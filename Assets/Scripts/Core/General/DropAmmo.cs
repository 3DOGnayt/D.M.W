using System.Collections.Generic;
using UnityEngine;

public class DropAmmo : MonoBehaviour
{
    //[SerializeField] private Enemy _enemy;
    [SerializeField] private List<GameObject> _ammo = new List<GameObject>();

    //private void Awake()
    //{
    //    _enemy = GetComponent<Enemy>();
    //}

    //private void Update()
    //{
    //    if (_enemy.gameObject == null)
    //    {
    //        Drop();
    //    }
    //    else return;
    //}

    public void Drop()
    {
        int ranom = Random.Range(0, _ammo.Count);
        Instantiate(_ammo[ranom], transform.position, transform.rotation);
    }
}
