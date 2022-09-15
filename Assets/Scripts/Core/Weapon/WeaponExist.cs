using UnityEngine;

public abstract class WeaponExist : MonoBehaviour, ICreateWeapon
{
    public abstract void CreateWeapon(int i);
}
