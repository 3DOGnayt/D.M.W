using UnityEngine;

public abstract class Ammo : MonoBehaviour, ICreateAmmo
{
    public abstract void CreateAmmo(int i);
}
