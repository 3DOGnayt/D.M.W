using System;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionDispenser : MonoBehaviour
{
    //[SerializeField] private float _ammunition;
    //[SerializeField] private float _allAmmunition;
    ////[SerializeField] private Gun _bullet;   // need get access to All weapon
    //[SerializeField] private List<Weapon> _weapons;

    //[SerializeField] private Gun _and;

    private float _gun = 7;
    private float _sgun = 30;
    private float _shotgun = 6;
    private float _grenadeLauncher = 3;
    private float _sniperRifle = 5;
    private float _eye = 100;

    #region hmm
    //[Serializable]
    //public struct WeaponInfo
    //{
    //    public enum WeaponChoise
    //    {
    //        Gun,
    //        SGun,
    //        Shotgun,
    //        SniperRifle,
    //        Granadelauncher,
    //        Eye
    //    }

    //    public WeaponChoise _type;
    //    public GameObject _prefab;
    //    public int _bulletCount;

    //}

    //[SerializeField] private List<WeaponInfo> weaponInfos;
    #endregion   

    private void Start()
    {
        //_and = GetComponent<Gun>();
    }

    public void TakeAmmo()
    {
        if (gameObject.TryGetComponent(out Gun gun))
        {
            gun._allAmmoGun += _gun;
        }

        if (gameObject.TryGetComponent(out SGun sgun))
        {
            sgun._allAmmo = sgun._allAmmo + _sgun;
        }

        if (gameObject.TryGetComponent(out Shotgun shotgun))
        {
            shotgun._allAmmo = shotgun._allAmmo + _shotgun;
        }

        if (gameObject.TryGetComponent(out GrenadeLauncher grenadeLauncher))
        {
            grenadeLauncher._allAmmo = grenadeLauncher._allAmmo + _grenadeLauncher;
        }

        if (gameObject.TryGetComponent(out SniperRifle sniperRifle))
        {
            sniperRifle._allAmmo = sniperRifle._allAmmo + _sniperRifle;
        }

        if (gameObject.TryGetComponent(out Eye eye))
        {
            eye._allAmmo = eye._allAmmo + _eye;
        }


        //_ammunition = _bullet._ammo;
        //_allAmmunition = _bullet._allAmmo;
        //_bullet._allAmmo = _allAmmunition + _ammunition;

    }

}
