using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    [SerializeField] private CreateWeaponController _createWeaponController;
    [SerializeField] private Image _weaponImage;
    [SerializeField] private List<Sprite> _weaponSprites;

    //private int _weaponNumber;

    private void Start()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    private void Update()
    {
        if (_createWeaponController._createdWeapon.Count >= 1)
        {
            for (int i = 0; i < _createWeaponController._createdWeapon.Count; i++)
            {
                if (_createWeaponController._createdWeapon[i] == null)
                    return;
                else if (_createWeaponController._createdWeapon[i].activeSelf == true)
                {
                    _weaponImage.sprite = _weaponSprites[i];
                }
            }

            //if (_createWeaponController._createdWeapon[1].TryGetComponent(out SGun sGun) && _createWeaponController._createdWeapon[1].activeSelf == true)
            //{
            //    _weaponImage.sprite = _weaponSprites[1];
            //}
            //else return;

            //if (_createWeaponController._createdWeapon[2].TryGetComponent(out Shotgun shotgun) && _createWeaponController._createdWeapon[2].activeSelf == true)
            //{
            //    _weaponImage.sprite = _weaponSprites[2];
            //}
            //else return;

            //if (_createWeaponController._createdWeapon[3].TryGetComponent(out GrenadeLauncher grenadeLauncher) && _createWeaponController._createdWeapon[3].activeSelf == true)
            //{
            //    _weaponImage.sprite = _weaponSprites[3];
            //}
            //else return;

            //if (_createWeaponController._createdWeapon[4].TryGetComponent(out SniperRifle sniperRifle) && _createWeaponController._createdWeapon[4].activeSelf == true)
            //{
            //    _weaponImage.sprite = _weaponSprites[4];
            //}
            //else return;

            //if (_createWeaponController._createdWeapon[5].TryGetComponent(out Eye eye) && _createWeaponController._createdWeapon[5].activeSelf == true)
            //{
            //    _weaponImage.sprite = _weaponSprites[5];
            //}
            //else return;
        }        
    }
}
