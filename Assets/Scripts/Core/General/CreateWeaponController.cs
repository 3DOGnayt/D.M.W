using System.Collections.Generic;
using UnityEngine;

public class CreateWeaponController : Weapon
{
    [SerializeField] public List<GameObject> _weaponList;
    //[SerializeField] private Transform _transformWeapon;
    [SerializeField] private Transform _arsenal;
    [SerializeField] private WeaponController _weaponController;

    public List<GameObject> _createdWeapon = new List<GameObject>();

    //public Dictionary<GameObject, Pool> _weaponPool = new Dictionary<GameObject, Pool>();

    public override void CreateWeapon(int i)
    {
        if (_weaponList[i] != null)
        {
            var emptyContainer = new GameObject();

            var weapon = Instantiate(_weaponList[i], _arsenal.transform, emptyContainer); // after
            //var weapon = Instantiate(_weaponInPool[i], container.transform.position, transform.rotation); before

            //_weaponPool[_weaponList[i]] = new Pool(emptyContainer.transform);
            _createdWeapon.Add(weapon);

            Destroy(emptyContainer);
            _weaponController.DeactivateWeapon();
        }
        else if (_weaponList[i] = null)
        {
            return;
        };
    }    
}
