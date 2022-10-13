using UnityEngine;

class AmmoController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [Space]
    [SerializeField] private CreateAmmoController _createAmmo;

    public void GetAmmo(int i)
    {
        if (_player._haveAmmo == false)
        {
            _createAmmo.CreateMagazin(i);
            _createAmmo.CreateAmmo(i);
        }
        else return;
    }    
}
