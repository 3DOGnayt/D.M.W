using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    [SerializeField] private Text _ammoText;
    [SerializeField] private CreateWeaponController _createWeapon;

    //private int _numberWeapon;

    private void Start()
    {
        _createWeapon = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    private void Update()
    {
        if(_createWeapon._createdWeapon.Count >= 1)
        {
            #region case 2
            for (int i = 0; i < _createWeapon._createdWeapon.Count; i++)
            {
                if (_createWeapon._createdWeapon[i] == null) { }
                else if (_createWeapon._createdWeapon[i].TryGetComponent(out Gun gun) && _createWeapon._createdWeapon[i].activeSelf == true)
                {
                    _ammoText.text = gun._ammo + " |" + gun._allAmmo;
                }
                else if (_createWeapon._createdWeapon[i].TryGetComponent(out SGun sgun) && _createWeapon._createdWeapon[i].activeSelf == true)
                {
                    _ammoText.text = sgun._ammo + " |" + sgun._allAmmo;
                }
                else if (_createWeapon._createdWeapon[i].TryGetComponent(out Shotgun shotgun) && _createWeapon._createdWeapon[i].activeSelf == true)
                {
                    _ammoText.text = shotgun._ammo + " |" + shotgun._allAmmo;
                }
                else if (_createWeapon._createdWeapon[i].TryGetComponent(out GrenadeLauncher grenadeLauncher) && _createWeapon._createdWeapon[i].activeSelf == true)
                {
                    _ammoText.text = grenadeLauncher._ammo + " |" + grenadeLauncher._allAmmo;
                }
                else if (_createWeapon._createdWeapon[i].TryGetComponent(out SniperRifle sniperRifle) && _createWeapon._createdWeapon[i].activeSelf == true)
                {
                    _ammoText.text = sniperRifle._ammo + " |" + sniperRifle._allAmmo;
                }
                else if (_createWeapon._createdWeapon[i].TryGetComponent(out Eye eye) && _createWeapon._createdWeapon[i].activeSelf == true)
                {
                    _ammoText.text = eye._ammo + " |" + eye._allAmmo;
                }
            }
            #endregion

            #region case 1
            //if (_createWeapon._createdWeapon[0] == null)
            //    return;
            //else if (_createWeapon._createdWeapon[0].TryGetComponent(out Gun gun) && _createWeapon._createdWeapon[0].activeSelf == true)
            //{
            //    _ammoText.text = gun._ammo + " |" + gun._allAmmo;
            //}

            //if (_createWeapon._createdWeapon[1] == null)
            //    return;
            //else if (_createWeapon._createdWeapon[1].TryGetComponent(out SGun sGun) && _createWeapon._createdWeapon[1].activeSelf == true)
            //{
            //    _ammoText.text = sGun._ammo + " |" + sGun._allAmmo;
            //}

            //if (_createWeapon._createdWeapon[2] == null)
            //    return;
            //else if (_createWeapon._createdWeapon[2].TryGetComponent(out Shotgun shotgun) && _createWeapon._createdWeapon[2].activeSelf == true)
            //{
            //    _ammoText.text = shotgun._ammo + " |" + shotgun._allAmmo;
            //}

            //if (_createWeapon._createdWeapon[3] == null)
            //    return;
            //else if (_createWeapon._createdWeapon[3].TryGetComponent(out GrenadeLauncher grenadeLauncher) && _createWeapon._createdWeapon[3].activeSelf == true)
            //{
            //    _ammoText.text = grenadeLauncher._ammo + " |" + grenadeLauncher._allAmmo;
            //}

            //if (_createWeapon._createdWeapon[4] == null)
            //    return;
            //else if (_createWeapon._createdWeapon[4].TryGetComponent(out SniperRifle sniperRifle) && _createWeapon._createdWeapon[4].activeSelf == true)
            //{
            //    _ammoText.text = sniperRifle._ammo + " |" + sniperRifle._allAmmo;
            //}

            //if (_createWeapon._createdWeapon[5] == null)
            //    return;
            //else if (_createWeapon._createdWeapon[5].TryGetComponent(out Eye eye) && _createWeapon._createdWeapon[5].activeSelf == true)
            //{
            //    _ammoText.text = eye._ammo + " |" + eye._allAmmo;
            //}
            #endregion
        }
    }
}
