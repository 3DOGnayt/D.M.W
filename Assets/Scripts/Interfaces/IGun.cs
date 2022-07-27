interface IGun : IWeapon, IReload, IAmmo, IDamage, IAmmunitionConsumption
{
    void GunFire();
}