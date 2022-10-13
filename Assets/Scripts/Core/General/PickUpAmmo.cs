using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    [SerializeField] private CreateWeaponController _createWeaponController;
    [SerializeField] private AmmunitionDispenser _ammunitionDispenser;
    [SerializeField] private int _numberWeapon;

    private bool _addAmmo;

    private void Start()
    {
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
        _ammunitionDispenser = _createWeaponController._createdWeapon[_numberWeapon].GetComponent<AmmunitionDispenser>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            if (_ammunitionDispenser.gameObject != null && _addAmmo == false) // now we have all weapons
            {
                _addAmmo = true;
                _ammunitionDispenser.TakeAmmo();
                Debug.Log("Add ammo");
            }
            else return;            
        }
        Destroy(gameObject);
    }
}
