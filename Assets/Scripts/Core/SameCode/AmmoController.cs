using UnityEngine;

class AmmoController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [Space]
    [SerializeField] private CreateAmmoController _createAmmo;

    private void Awake()
    {
        _createAmmo = GetComponent<CreateAmmoController>();
    }

    private void Start()
    {
        if (_player._haveWeapon == false && _player._haveAmmo == false)
        {
            // why?
        }
    }

    private void Update()
    {
        
    }

}
