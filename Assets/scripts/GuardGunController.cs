using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardGunController : GunController
{
    public bool Shoot = false;
    public int Burst = 3;
    private int _shotCount = 0;
    private double _burstTimer = 0;
    public override void GunUpdate()
    {
        if (_gun.ShootTimer > 0) { _gun.ShootTimer -= Time.fixedDeltaTime; }
        if(_burstTimer > 0) { _burstTimer -= Time.fixedDeltaTime; _shotCount = 0; }
        if (Shoot && _gun.ShootTimer <= 0 && _shotCount < Burst && _burstTimer <= 0) {
            _gun.Shoot();
            if (++_shotCount >= Burst)
            {
                _burstTimer = 1;
            }
        }
    }
}
