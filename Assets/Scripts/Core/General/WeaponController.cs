using UnityEngine;

class WeaponController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [Space]
    [SerializeField] private CreateWeaponController _createWeapon;
    [SerializeField] private AmmoController _ammoController;

    private void Awake()
    {
        if (_player._haveWeapon == false)
        {
            for (int i = 0; i < _createWeapon._weaponList.Count; i++)
            {
                _createWeapon.CreateWeapon(i);
                _ammoController.GetAmmo(i);
            }
            DeactivateWeapon();
        }
        else return;
    }

    public void DeactivateWeapon()  // This method eat so much, need optimize
    {
        for (int i = 0; i < _createWeapon._createdWeapon.Count; i++)
        {
            _createWeapon._createdWeapon[i].SetActive(false);
        }
    }

    private void Update()  // only button click need to do this / remove non used weapon
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && !_player._haveWeapon)
        {
            DeactivateWeapon();
            _createWeapon._createdWeapon[0].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && !_player._haveWeapon)
        {
            DeactivateWeapon();
            _createWeapon._createdWeapon[1].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && !_player._haveWeapon)
        {
            DeactivateWeapon();
            _createWeapon._createdWeapon[2].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && !_player._haveWeapon)
        {
            DeactivateWeapon();
            _createWeapon._createdWeapon[3].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && !_player._haveWeapon)
        {
            DeactivateWeapon();
            _createWeapon._createdWeapon[4].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && !_player._haveWeapon)
        {
            DeactivateWeapon();
            _createWeapon._createdWeapon[5].SetActive(true);
        }
    }
}