using UnityEngine;

public class AmmoPool : Controllers
{
    private CreateWeaponController _createWeaponController;
    private CreateAmmoController _createAmmoController;

    private GameObject _createdAmmo;
    private Bullet _bullet;

    private void Start()
    {
        _createAmmoController = GameObject.FindGameObjectWithTag("CreateAmmoController").GetComponent<CreateAmmoController>();
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    public void CreateAmmo(int i)
    {
        for (int e = 0; e < _createWeaponController._createdWeapon[i].GetComponent<IAmmo>()._ammo; e++)
        {
            _createdAmmo = Instantiate(_createAmmoController._ammoList[i], _createAmmoController.AllMagazins[i].transform, false);

            switch (i)
            {
                case 0:
                    _createAmmoController.GunMagazin.Add(_createdAmmo);
                    break;
                case 1:
                    _createAmmoController.SgunMagazin.Add(_createdAmmo);
                    break;
                case 2:
                    _createAmmoController.ShotgunMagazin.Add(_createdAmmo);
                    break;
                case 3:
                    _createAmmoController.GrenadeLauncherMagazin.Add(_createdAmmo);
                    break;
                case 4:
                    _createAmmoController.SniperRifleMagazin.Add(_createdAmmo);
                    break;
                case 5:
                    _createAmmoController.EyeMagazin.Add(_createdAmmo);
                    break;
                default:
                    _createAmmoController.SameMagazine.Add(_createdAmmo);
                    break;
            }
            //_bullet.gameObject.SetActive(false);
            _createdAmmo.SetActive(false);
        }
    }

    public void Fire(Vector3 position, Quaternion rotation, float damage, int ammo, int allAmmo)
    {
        _createAmmoController.GunMagazin[allAmmo - ammo].transform.position = position;
        _createAmmoController.GunMagazin[allAmmo - ammo].transform.rotation = rotation;
        _createAmmoController.GunMagazin[allAmmo - ammo].gameObject.SetActive(true);
        var b = _createAmmoController.GunMagazin[allAmmo - ammo].GetComponent<Bullet>();
        b.InitDamage(damage);
    }
}
