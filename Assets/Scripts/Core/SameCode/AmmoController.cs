using UnityEngine;

class AmmoController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [Space]
    [SerializeField] private CreateAmmoController _createAmmo;
    [SerializeField] private CreateWeaponController _createWeapon;

    public void GetAmmo(int i)
    {
        if (_player._haveAmmo == false)
        {
            _createAmmo.CreateMagazin(i);
            _createAmmo.CreateAmmo(i);

            //for (int h = 0; h < _createAmmo._allMagazins.Count; h++)
            //{
            //    _createAmmo.CreateAmmo(h);
            //}
            //deactibate ammo
        }
        else return;
    }    
}
