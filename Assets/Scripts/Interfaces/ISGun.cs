interface ISGun : IWeapon, IReload, IAmmo, IDamage, IAmmunitionConsumption
{
    void SGunFire();
}