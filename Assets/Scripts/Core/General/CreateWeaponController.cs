using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateWeaponController : WeaponExist
{
    [SerializeField] private Transform _arsenal;
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private PlayerInventory _playerInventory;

    private GameObject[] _weapon = new GameObject[6];

    public List<GameObject> _weaponList;
    public List<GameObject> _createdWeapon = new List<GameObject>();

    private void Start()
    {
        _weaponList.InsertRange(0, _weapon);
        _createdWeapon.InsertRange(0, _weapon);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            for (int i = 0; i < _weaponList.Count; i++)
            {
                _playerInventory._weaponSaved[i] = _weaponList[i];
            }
            Debug.Log("Save inventory");
        }
        else
        {
            for (int i = 0; i < _weaponList.Count; i++)
            {
                _weaponList[i] = _playerInventory._weaponSaved[i];
            }
            Debug.Log("Give inventory");
        }

        for (int i = 0; i < _weaponList.Count; i++)
        {
            if (_weaponList[i] != null)
            {
                CreateWeapon(i);
            }            
        }
    }

    public override void CreateWeapon(int i)
    {
        if (_weaponList[i] != null)
        {
            var emptyContainer = new GameObject();

            var weapon = Instantiate(_weaponList[i], _arsenal.transform, emptyContainer);
            _createdWeapon.RemoveAt(i);
            _createdWeapon.Insert(i, weapon);

            Destroy(emptyContainer);
            DeactivateWeapon();
            _createdWeapon[i].SetActive(true);
        }
        else if (_weaponList[i] = null)
        {            
            return;
        };
    }

    public void DeactivateWeapon() // need update this method / concrete weapon activated => previous deactivated
    {
        for (int i = 0; i < _createdWeapon.Count; i++)
        {
            if (_createdWeapon[i] != null)
            {
                _createdWeapon[i].SetActive(false);
            }
        }
    }
}
