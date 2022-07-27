using System.Collections.Generic;
using UnityEngine;

public class CreateAmmoController : MonoBehaviour
{
    [SerializeField] public List<GameObject> _ammo;
    //[SerializeField] private Transform _transform;
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private AmmoController _ammoController;

    public List<float> _ammoInMagazine = new List<float>();

    private void CreateAmmo()
    {
        //why?
    }
}
