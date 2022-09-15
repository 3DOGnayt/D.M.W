using System.Collections.Generic;
using UnityEngine;

public class PickUpAmmo : MonoBehaviour
{
    [SerializeField] private GameObject _sameWeapon; // prefab only 
    //[SerializeField] private CreateAmmoController _createAmmoController;
    [SerializeField] private CreateWeaponController _createWeaponController;
    //[SerializeField] private Material _material;
    [SerializeField] private List<AmmunitionDispenser> _listAD = new List<AmmunitionDispenser>();
    [SerializeField] private AmmunitionDispenser _ammunitionDispenser;
    [SerializeField] private int _numberWeapon;

    //public List<GameObject> _weapon = new List<GameObject>();

    private void Start()
    {
        //int _colorWeapon = 0;
        //_colorWeapon = Random.Range(0, _listAD.Count);
        _createWeaponController = GameObject.FindGameObjectWithTag("CreateWeaponController").GetComponent<CreateWeaponController>();
        _ammunitionDispenser = GameObject.FindGameObjectWithTag("Weapon").GetComponent<AmmunitionDispenser>();
        _ammunitionDispenser = _createWeaponController._createdWeapon[_numberWeapon].GetComponent<AmmunitionDispenser>();
        //_ammunitionDispenser = _listAD[Random.Range(0, _listAD.Count)];


        //switch (_colorWeapon)
        //{
        //    case 0:
        //        _material.color = Color.red;
        //        break;
        //    case 1:
        //        _material.color = Color.blue;
        //        break;
        //    case 2:
        //        _material.color = Color.yellow;
        //        break;
        //    case 3:
        //        _material.color = Color.green;
        //        break;
        //    case 4:
        //        _material.color = Color.black;
        //        break;
        //    case 5:
        //        _material.color = Color.cyan;
        //        break;
        //    default:
        //        _material.color = Color.white;
        //        break;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out _))
        {
            // if weapon exist in _createWeapon => _ammoAll++ // a little bit later

            if (_ammunitionDispenser.gameObject != null) // now we have all weapons
            {
                _ammunitionDispenser.TakeAmmo();
                Destroy(gameObject);
                Debug.Log("And where ammo add?");
            }
            else
            {
                //return;
                Destroy(gameObject);
                Debug.Log("just destroy");
            }
        }
    }
}
