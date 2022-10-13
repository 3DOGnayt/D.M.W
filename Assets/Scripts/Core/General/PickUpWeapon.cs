using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _sameWeapon; // prefab only
    [SerializeField] private CreateWeaponController _createWeaponController;

    private void Awake()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            if (_createWeaponController._weaponList.Contains(_sameWeapon) == true)
            {
                Destroy(gameObject);
            }
            else
            {
                _createWeaponController._weaponList.Insert(0, _sameWeapon);
                //_createWeaponController._weaponList.Add(_sameWeapon);
                _createWeaponController.CreateWeapon(_createWeaponController._weaponList.Count - 1);
                Destroy(gameObject);
            }            
        }
    }
}
