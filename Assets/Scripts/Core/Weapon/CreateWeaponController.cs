using Assets.Scripts.Core.Weapon;
using System.Collections.Generic;
using UnityEngine;

public class CreateWeaponController : Weapon
{
    [SerializeField] public List<GameObject> _weapon;
    [SerializeField] private Transform _transformWeapon;
    [SerializeField] private WeaponController weaponController;

    public List<GameObject> a = new List<GameObject>();  // this need to instantiate weapon/  change to dictionary
    
    public override void CreateWeapon(int i)
    {
        if (_weapon[i] != null)
        {
            var weapon = Instantiate(_weapon[i], _transformWeapon.position, transform.rotation);
            a.Add(weapon);
            weaponController.DeactivateWeapon();
        }
        else if (_weapon[i] = null)
        {
            return;
        };
    }
}
