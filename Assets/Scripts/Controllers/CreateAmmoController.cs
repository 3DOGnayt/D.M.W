using System.Collections.Generic;
using UnityEngine;

public class CreateAmmoController : Controllers
{
    [SerializeField] public List<GameObject> _ammoList;
    [SerializeField] private CreateWeaponController _createWeapon;
    [Space]
    [SerializeField] private List<GameObject> _allMagazins = new List<GameObject>(6);
    [SerializeField] private List<GameObject> _gunMagazin;
    [SerializeField] private List<GameObject> _sgunMagazin;
    [SerializeField] private List<GameObject> _shotgunMagazin;
    [SerializeField] private List<GameObject> _grenadeLauncherMagazin;
    [SerializeField] private List<GameObject> _SniperRifleMagazin;
    [SerializeField] private List<GameObject> _eyeMagazin;
    [SerializeField] private List<GameObject> _sameMagazine;

    public List<GameObject> AllMagazins { get => _allMagazins; set => _allMagazins = value; }
    public List<GameObject> GunMagazin { get => _gunMagazin; set => _gunMagazin = value; }
    public List<GameObject> SgunMagazin { get => _sgunMagazin; set => _sgunMagazin = value; }
    public List<GameObject> ShotgunMagazin { get => _shotgunMagazin; set => _shotgunMagazin = value; }
    public List<GameObject> GrenadeLauncherMagazin { get => _grenadeLauncherMagazin; set => _grenadeLauncherMagazin = value; }
    public List<GameObject> SniperRifleMagazin { get => _SniperRifleMagazin; set => _SniperRifleMagazin = value; }
    public List<GameObject> EyeMagazin { get => _eyeMagazin; set => _eyeMagazin = value; }
    public List<GameObject> SameMagazine { get => _sameMagazine; set => _sameMagazine = value; }

    private void Start()
    {
        AllMagazins.InsertRange(0, new GameObject[6]);
    }

    public void CreateMagazin(int i)
    {
        if (_ammoList[i] != null)
        {
            var emptyContainer = new GameObject();
            var magazin = Instantiate(emptyContainer, _createWeapon._createdWeapon[i].transform, false);

            string a = "Magazin";
            magazin.name = a.ToString();
            AllMagazins.RemoveAt(i);
            AllMagazins.Insert(i, magazin);
            Destroy(emptyContainer);
        }
        else if (_ammoList[i] == null) return;
    }
}
