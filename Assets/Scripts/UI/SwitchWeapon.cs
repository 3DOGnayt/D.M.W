using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] private Button _weaponNext;
    [SerializeField] private Button _weaponPrevious;
    [Space]
    [SerializeField] private CreateWeaponController _createWeaponController;

    private void Awake()
    {
        _weaponPrevious.onClick.AddListener(PreviousWeapon);
        _weaponNext.onClick.AddListener(NextWeapon);
    }

    private void Start()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    private void NextWeapon()
    {
        for (int i = 0; i < _createWeaponController._createdWeapon.Count; i++)
        {
            if (_createWeaponController._createdWeapon[i] == null) { }
            else if (_createWeaponController._createdWeapon[i].activeSelf == true)
            {
                if(_createWeaponController._createdWeapon.Count - 1 == i)
                {
                    Next(i, - 1);
                    return;
                }                
                else if (i < _createWeaponController._createdWeapon.Count)
                {
                    Next(i, i);
                    return;
                }
            }
        }
    }

    private void Next(int a , int b)
    {
        _createWeaponController._createdWeapon[a].SetActive(false);
        _createWeaponController._createdWeapon[b + 1].SetActive(true);
    }

    private void PreviousWeapon()
    {
        for (int i = 0; i < _createWeaponController._createdWeapon.Count; i++)
        {
            if (_createWeaponController._createdWeapon[i] == null) { }
            else if (_createWeaponController._createdWeapon[i].activeSelf == true)
            {
                if (i == 0)
                {
                    Previous(i, _createWeaponController._createdWeapon.Count);
                    return;
                }
                else if (i <= _createWeaponController._createdWeapon.Count)
                {
                    Previous(i, i);
                    return;
                }
            }
        }
    }

    private void Previous(int a , int b)
    {
        _createWeaponController._createdWeapon[a].SetActive(false);
        _createWeaponController._createdWeapon[b - 1].SetActive(true);
    }
}
