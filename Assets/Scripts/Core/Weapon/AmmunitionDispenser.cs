using UnityEngine;

public class AmmunitionDispenser : MonoBehaviour
{
    private float _gun = 7;
    private float _sgun = 30;
    private float _shotgun = 6;
    private float _grenadeLauncher = 3;
    private float _sniperRifle = 5;
    private float _eye = 100;

    public void TakeAmmo()
    {
        if (gameObject.TryGetComponent(out Gun gun))
        {
            gun._allAmmoGun += _gun;
        }

        if (gameObject.TryGetComponent(out SGun sgun))
        {
            sgun._allAmmo += _sgun;
        }

        if (gameObject.TryGetComponent(out Shotgun shotgun))
        {
            shotgun._allAmmo += _shotgun;
        }

        if (gameObject.TryGetComponent(out GrenadeLauncher grenadeLauncher))
        {
            grenadeLauncher._allAmmo += _grenadeLauncher;
        }

        if (gameObject.TryGetComponent(out SniperRifle sniperRifle))
        {
            sniperRifle._allAmmo += _sniperRifle;
        }

        if (gameObject.TryGetComponent(out Eye eye))
        {
            eye._allAmmo += _eye;
        }
    }
}
