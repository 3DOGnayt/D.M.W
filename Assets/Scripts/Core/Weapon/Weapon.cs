using UnityEngine;

public abstract class Weapon : MonoBehaviour, ICreateWeapon
{
    public abstract void CreateWeapon(int i);
}
