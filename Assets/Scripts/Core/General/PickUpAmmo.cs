using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    [SerializeField] private GameObject _sameWeapon; // prefab only 
    [SerializeField] private CreateAmmoController _createAmmoController;
    [SerializeField] private CreateWeaponController _createWeaponController;

    //public List<GameObject> _weapon = new List<GameObject>();

    private void Awake()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("Weapon").GetComponent<CreateWeaponController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            // if weapon exist in _createWeapon => _ammoAll++

            if (_createWeaponController._createdWeapon.Contains(_sameWeapon) == true)
            {
                //allAmmoGun = + ammoGun*2;
            }
        }
    }


    //private void OnTriggerEnter(Collider other) // this long method
    //{
    //    if (other.gameObject.TryGetComponent<Player>(out _))
    //    {
    //        if (_createAmmoController._ammo.Contains(_sameAmmo) == true)
    //        {
    //            Destroy(gameObject);
    //        }
    //        else
    //        {
    //            _createAmmoController._ammo.Add(_sameAmmo);
    //            _createAmmoController.CreateAmmo(_createAmmoController._ammo.Count - 1);
    //            Destroy(gameObject);
    //        }
    //    }
    //}
}
