using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    [SerializeField] private Button _attack;
    //[SerializeField] private CreateWeaponController _createWeapon;

    public bool _click = false;

    private void Awake()
    {
        _attack.onClick.AddListener(Piu);
    }

    //private void Start()
    //{
    //    _createWeapon = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    //}

    //private void Update()
    //{
    //    for (int i = 0; i < _createWeapon._createdWeapon.Count; i++)
    //    {
    //        if (_createWeapon._createdWeapon[i] == null) { }
    //        else if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) && _createWeapon._createdWeapon[i].activeSelf == true)
    //        {
    //            Piu();
    //        }
    //    }
    //}

    public void Piu()
    {
        _click = true;
        Debug.Log("piu");

        #region turn 1
        //for (int i = 0; i < _createWeapon._createdWeapon.Count; i++)
        //{
        //    if (_createWeapon._createdWeapon[i] == null) { }
        //    else if (_createWeapon._createdWeapon[i].TryGetComponent(out Gun gun) && _createWeapon._createdWeapon[i].activeSelf == true)
        //    {
        //        gun.GunFire();
        //    }
        //    else if (_createWeapon._createdWeapon[i].TryGetComponent(out SGun sgun) && _createWeapon._createdWeapon[i].activeSelf == true)
        //    {
        //        sgun.SGunFire();
        //    }
        //    else if (_createWeapon._createdWeapon[i].TryGetComponent(out Shotgun shotgun) && _createWeapon._createdWeapon[i].activeSelf == true)
        //    {
        //        shotgun.ShotgunFire();
        //    }
        //    else if (_createWeapon._createdWeapon[i].TryGetComponent(out GrenadeLauncher grenadeLauncher) && _createWeapon._createdWeapon[i].activeSelf == true)
        //    {
        //        grenadeLauncher.GranadeLauncherFire();
        //    }
        //    else if (_createWeapon._createdWeapon[i].TryGetComponent(out SniperRifle sniperRifle) && _createWeapon._createdWeapon[i].activeSelf == true)
        //    {
        //        sniperRifle.SniperRifleFire();
        //    }
        //    else if (_createWeapon._createdWeapon[i].TryGetComponent(out Eye eye) && _createWeapon._createdWeapon[i].activeSelf == true)
        //    {
        //        eye.LaserFire();
        //    }
        //}
        #endregion
    }
}
