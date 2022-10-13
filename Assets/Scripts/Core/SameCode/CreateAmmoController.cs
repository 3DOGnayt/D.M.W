using System.Collections.Generic;
using UnityEngine;

public class CreateAmmoController : Ammo
{
    [SerializeField] public List<GameObject> _ammoList;
    [SerializeField] private CreateWeaponController _createWeapon;

    public List<GameObject> _allMagazins = new List<GameObject>();
    public List<GameObject> _ammoInMagazine = new List<GameObject>();

    public void CreateMagazin(int i) 
    {
        if (_ammoList[i] != null)
        {
            var emptyContainer = new GameObject();
            var magazin = Instantiate(emptyContainer, _createWeapon._createdWeapon[i].transform, false);

            string a = "Magazin";
            magazin.name = a.ToString();
            _allMagazins.Add(magazin);
            Destroy(emptyContainer);
        }
        else if (_ammoList[i] == null)
        {
            return;
        }
    }

    public override void CreateAmmo(int i)
    {
        for (int e = 0; e < 10; e++)
        {
            var ammo = Instantiate(_ammoList[i], _allMagazins[i].transform, false);
            _ammoInMagazine.Add(ammo);
            ammo.SetActive(false);
        }        
    }
}
