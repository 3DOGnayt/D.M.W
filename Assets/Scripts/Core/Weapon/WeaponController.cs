using UnityEngine;

namespace Assets.Scripts.Core.Weapon
{
    class WeaponController : MonoBehaviour
    {
        public Player _player;
        [Space]
        public CreateWeaponController _createGun;

        private void Start()
        {
            if (_player._haveWeapon == false)
            {
                for (int i = 0; i < _createGun._weapon.Count; i++)
                {
                    _createGun.CreateWeapon(i);
                }
                DeactivateWeapon();
            }
            else return;
        }

        public void DeactivateWeapon()  // This method eat so much, need optimize
        {
            for (int i = 0; i < _createGun.a.Count; i++)
            {
                _createGun.a[i].SetActive(false);
            }
        }

        private void Update()  // only button click need to do this
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && !_player._haveWeapon)
            {
                DeactivateWeapon();
                _createGun.a[0].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && !_player._haveWeapon)
            {
                DeactivateWeapon();
                _createGun.a[1].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && !_player._haveWeapon)
            {
                DeactivateWeapon();
                _createGun.a[2].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !_player._haveWeapon)
            {
                DeactivateWeapon();
                _createGun.a[3].SetActive(true);
            } 
            else if (Input.GetKeyDown(KeyCode.Alpha5) && !_player._haveWeapon)
            {
                DeactivateWeapon();
                _createGun.a[4].SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6) && !_player._haveWeapon)
            {
                DeactivateWeapon();
                _createGun.a[5].SetActive(true);
            }

        }
    }
}
