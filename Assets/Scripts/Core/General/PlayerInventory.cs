using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInventory : ScriptableObject
{
    [SerializeField] public List<GameObject> _weaponSaved;
}
