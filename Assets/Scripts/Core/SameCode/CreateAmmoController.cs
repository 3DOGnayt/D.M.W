using System.Collections.Generic;
using UnityEngine;

public class CreateAmmoController : Ammo
{
    [SerializeField] public List<GameObject> _ammoList;
    [SerializeField] private AmmoController _ammoController; // for deactivate ammo, but...
    [SerializeField] private CreateWeaponController _createWeapon;
    //[SerializeField] private GameObject _magazin;

    public List<GameObject> _allMagazins = new List<GameObject>();
    public List<GameObject> _ammoInMagazine = new List<GameObject>();

    //public Dictionary<GameObject, Pool> _ammoPool = new Dictionary<GameObject, Pool>();

    public void CreateMagazin(int i) 
    {
        #region weapon version 
        //if (_ammoInPool[i] != null)
        //{
        //    var emptyContainer = new GameObject();

        //    var ammo = Instantiate(_ammoInPool[i], transform, emptyContainer);
        //    _ammoPool[_ammoInPool[i]] = new Pool(emptyContainer.transform);
        //    _ammoInMagazine.Add(ammo);

        //    Destroy(emptyContainer);
        //}
        //else if (_ammoInPool[i] = null)
        //{
        //    return;
        //}
        #endregion

        if (_ammoList[i] != null)
        {
            //_magazine[i] = _createWeapon._createdWeapon[i].transform;

            var emptyContainer = new GameObject();
            var magazin = Instantiate(emptyContainer, _createWeapon._createdWeapon[i].transform, false);

            string a = "Magazin";
            magazin.name = a.ToString();
            _allMagazins.Add(magazin);

            //_ammoPool[_ammoList[i]] = new Pool(emptyContainer.transform);
            //_ammoInMagazine.Add(magazine);
                     
            Destroy(emptyContainer);
            // deactivate ammo
        }
        else if (_ammoList[i] == null)
        {
            return;
        }
    }

    public override void CreateAmmo(int i)
    {
        //if (_allMagazins[i] != null)
        //{
        //    for (int j = 0; j < 10; j++)
        //    {
        //        var ammo = Instantiate(_ammoList[j], _allMagazins[j].transform, false);
        //        _ammoInMagazine.Add(ammo);
        //    }            
        //}

        for (int e = 0; e < 10; e++)
        {
            var ammo = Instantiate(_ammoList[i], _allMagazins[i].transform, false);
            _ammoInMagazine.Add(ammo);
        }        
    }
}
