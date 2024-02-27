using UnityEngine;

class AmmoController : Controllers
{
    [SerializeField] private Player _player;
    [Space]
    [SerializeField] private CreateAmmoController _createAmmo;

    public void GetAmmo(int i)
    {
        if (_player._haveAmmo == false)
        {
            _createAmmo.CreateMagazin(i);
        }
        else return;
    }    
}
