using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    [SerializeField] private CreateWeaponController _createWeapon;
    //[SerializeField] private Texture2D _weaponTexture;
    //[SerializeField] private Sprite _weaponSprite;
    [SerializeField] private Image _weaponImage;
    //[SerializeField] private List<Texture2D> _weaponTextures;
    [SerializeField] private List<Sprite> _weaponSprites;
    //[SerializeField] private List<Image> _weaponImages;

    private void Start()
    {
        _createWeapon = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    private void Update()
    {
        if (_createWeapon._createdWeapon[0].TryGetComponent(out Gun gun) && _createWeapon._createdWeapon[0].activeSelf == true)
        {
            //_weaponImage = Instantiate(_weaponPrefabs[0], transform.parent);
            //texture.LoadImage( , true);
            _weaponImage.sprite = _weaponSprites[0];
        }

        if (_createWeapon._createdWeapon[1].TryGetComponent(out SGun sGun) && _createWeapon._createdWeapon[1].activeSelf == true)
        {
            //_weaponImage.sprite = Sprite.Create(_weaponPrefabs[1], Rect.zero, Vector2.zero);
            _weaponImage.sprite = _weaponSprites[1];
        }

        if (_createWeapon._createdWeapon[2].TryGetComponent(out Shotgun shotgun) && _createWeapon._createdWeapon[2].activeSelf == true)
        {
            _weaponImage.sprite = _weaponSprites[2];
        }

        if (_createWeapon._createdWeapon[3].TryGetComponent(out GrenadeLauncher grenadeLauncher) && _createWeapon._createdWeapon[3].activeSelf == true)
        {
            _weaponImage.sprite = _weaponSprites[3];
        }

        if (_createWeapon._createdWeapon[4].TryGetComponent(out SniperRifle sniperRifle) && _createWeapon._createdWeapon[4].activeSelf == true)
        {
            _weaponImage.sprite = _weaponSprites[4];
        }
        if (_createWeapon._createdWeapon[5].TryGetComponent(out Eye eye) && _createWeapon._createdWeapon[5].activeSelf == true)
        {
            _weaponImage.sprite = _weaponSprites[5];
        }
    }
}
