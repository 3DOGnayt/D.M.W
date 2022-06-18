using System.Collections.Generic;
using UnityEngine;

public class CreateWeaponController : Weapon
{
    [SerializeField] public GameObject[] _weapon;
    [SerializeField] private Transform _transformWeapon;

    public List<GameObject> a = new List<GameObject>();    
    
    public override void CreateWeapon(int i)
    {
        var weapon = Instantiate(_weapon[i], _transformWeapon.position, transform.rotation);
        a.Add(weapon);
    }
}
