using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _sameWeapon; // prefab only
    [SerializeField] private CreateWeaponController _createWeaponController;
    [SerializeField] private int _numberWeapon;

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
                _createWeaponController._weaponList.RemoveAt(_numberWeapon);
                _createWeaponController._weaponList.Insert(_numberWeapon, _sameWeapon);
                _createWeaponController.CreateWeapon(_numberWeapon);
                Destroy(gameObject);
            }            
        }
    }
}
