using System.Collections.Generic;
using UnityEngine;

public class CreateWeaponController : WeaponExist
{
    [SerializeField] private Transform _arsenal;
    [SerializeField] private WeaponController _weaponController;

    private GameObject[] _weapon = new GameObject[6];

    public List<GameObject> _weaponList;
    public List<GameObject> _createdWeapon = new List<GameObject>();

    private void Start()
    {
        _weaponList.InsertRange(0, _weapon);
    }

    public override void CreateWeapon(int i)
    {
        if (_weaponList[i] != null)
        {
            var emptyContainer = new GameObject();

            var weapon = Instantiate(_weaponList[i], _arsenal.transform, emptyContainer); 
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
