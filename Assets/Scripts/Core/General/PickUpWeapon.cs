using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _sameWeapon;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private CreateWeaponController _createWeaponController;

    private void Start()
    {
        _weapon = gameObject;
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            if (_createWeaponController._weaponInPool.Contains(_sameWeapon) == true)
            {
                Destroy(gameObject);
            }
            else
            {
                _createWeaponController._weaponInPool.Add(_sameWeapon);
                _createWeaponController.CreateWeapon(_createWeaponController._weaponInPool.Count - 1);
                Destroy(gameObject);
            }            
        }
    }
}
